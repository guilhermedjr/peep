using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Peep.Wings.Domain.Dtos;
using Peep.Wings.Domain.Entities;
using Peep.Wings.Domain.Services;
using Peep.Wings.Application.ViewModels;


namespace Peep.Wings.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : CustomControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;

        public AccountsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService,
            IEmailService emailService,
            ISmsService smsService) 
            : base(userManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenService = tokenService;
            this._emailService = emailService;
            this._smsService = smsService;
        }

      
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(RegistrationDto registrationDto)
        {
            var user = new ApplicationUser
            {
                Name = registrationDto.Name,
                Email = !String.IsNullOrEmpty(registrationDto.Email) ? registrationDto.Email : null,
                PhoneNumber = !String.IsNullOrEmpty(registrationDto.PhoneNumber) ? registrationDto.PhoneNumber : null,
                BirthDate = registrationDto.BirthDate,
                UserName = registrationDto.Username,
                Password = registrationDto.Password,
                JoinedAt = DateTime.Now,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false

            };

            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (!result.Succeeded)
                return BadRequest( new { result.Errors } );

            if (user.Email != null)
            {
                var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var emailConfirmationUrl = Url.Link("ConfirmEmail", new { token = emailToken, email = user.Email });

                await _emailService.SendEmail(
                    user.Email,
                    "Peep - Confirmação de email",
                    $"<html><body>Seja bem-vindo ao Peep! Clique <a href=\"{emailConfirmationUrl}\">aqui</a> para confirmar seu email e poder acessar a sua conta</body></html>");

                await _signInManager.SignInAsync(user, true);
            }

            //TODO: Confirmação de conta via número de telefone 

            var userView = new ApplicationUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.UserName
            };
                

            Response.Cookies.Append("peep_token", _tokenService.GenerateJsonWebToken(user), new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true,
                SameSite = SameSiteMode.Lax
            });

            return Created(
                Url.Link("GetById", new { Id = user }),
                userView);

        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            var user = 
                !String.IsNullOrEmpty(loginDto.Email)
                    ? await _userManager.FindByEmailAsync(loginDto.Email)
                    : !String.IsNullOrEmpty(loginDto.PhoneNumber)
                        ? await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == loginDto.PhoneNumber)
                        : await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.Username);

            if (user == null)
                return BadRequest( new { Message = "Informação de login incorreta" });


            var result = await _signInManager.PasswordSignInAsync(user.UserName, loginDto.Password, true, false);

            if (!result.Succeeded)
                return BadRequest( new { Message = "Senha incorreta" } );

            Response.Cookies.Append("peep_token", _tokenService.GenerateJsonWebToken(user), new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true,
                SameSite = SameSiteMode.Lax
            });

            return Ok();
        }


        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("peep_token");
            return NoContent();
        }


        [HttpGet]
        [Route("{id}", Name = "GetById")]
        [Authorize]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return NotFound();

            var authenticatedUser = await GetAuthenticatedUserAccount();

            if (authenticatedUser == null)
                return BadRequest( new { Message = "Usuário não autenticado" } );

            var userView = new ApplicationUserViewModel
            {
                Id = authenticatedUser.Id,
                Name = authenticatedUser.Name,
                Username = authenticatedUser.UserName
            };

            return Ok(userView);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(UpdateAccountDto updateAccountDto)
        {
            var authenticatedUser = await GetAuthenticatedUserAccount();

            if (authenticatedUser == null)
                return BadRequest( new { Message = "Usuário não autenticado" } );

            if (String.IsNullOrEmpty(updateAccountDto.Id.ToString()))
                return BadRequest( new { Message = "Identificador do usuário não informado" } );

            var user = await _userManager.FindByIdAsync(updateAccountDto.Id.ToString());

            if (user == null)
                return NotFound( new { Message = "Usuário não encontrado" } );

            if (!String.IsNullOrEmpty(updateAccountDto.Email) && 
                user.Email != updateAccountDto.Email)
            {
                if (await _userManager.Users.FirstOrDefaultAsync(u => u.Email == updateAccountDto.Email) != null)
                    return BadRequest( new { Message = "Email já utilizado em outra conta" } );

                user.EmailConfirmed = false;
                user.Email = updateAccountDto.Email;
                var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var emailConfirmationUrl = Url.Link("ConfirmEmail", new { token = emailToken, email = user.Email });
                await _emailService.SendEmail(
                   user.Email,
                   "Peep - Confirmação de email",
                   $"<html><body>Clique <a href=\"{emailConfirmationUrl}\">aqui</a> para confirmar seu novo email de acesso à sua conta Peep</body></html>");
            }

            if (!String.IsNullOrEmpty(updateAccountDto.PhoneNumber) &&
                user.PhoneNumber != updateAccountDto.PhoneNumber)
            {
                // TODO: confirmação de número de telefone
                user.PhoneNumber = updateAccountDto.PhoneNumber;
            }

            if (!String.IsNullOrEmpty(updateAccountDto.Username) &&
                user.UserName != updateAccountDto.Username)
            {
                if (await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == updateAccountDto.Username) != null)
                    return BadRequest( new { Message = "Nome de usuário já utilizado em outra conta" } );

                user.UserName = updateAccountDto.Username;
            }

            if (!String.IsNullOrEmpty(updateAccountDto.Name) &&
                user.Name != updateAccountDto.Name)
            {
                user.Name = updateAccountDto.Name;
            }

            if (!String.IsNullOrEmpty(updateAccountDto.NewPassword) &&
                user.Password != updateAccountDto.NewPassword)
            {
                if (String.IsNullOrEmpty(updateAccountDto.CurrentPassword))
                    return BadRequest( new { Message = "Uma nova senha foi informada, porém a atual não" } );

                if (!await _userManager.CheckPasswordAsync(user, updateAccountDto.CurrentPassword))
                    return BadRequest( new { Message = "Senha atual incorreta" } );

                await _userManager.ChangePasswordAsync(user, updateAccountDto.CurrentPassword, updateAccountDto.NewPassword);
            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return BadRequest( new { result.Errors } );

            var userView = new ApplicationUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.UserName
            };

            Response.Cookies.Append("peep_token", _tokenService.GenerateJsonWebToken(user), new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true,
                SameSite = SameSiteMode.Lax
            });

            return Ok(userView);
        }

        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);

            var result = await _userManager.ConfirmEmailAsync(user, token);

            string uiUrl = result.Succeeded ? "emailConfirmado" : "emailInexistente";

            // TODO: Fazer integração no front-end: criar as telas de email confirmado/não confirmado
            // e redirecionar para a home em caso positivo

            return Redirect(uiUrl);
        }

        [HttpPost]
        [Route("ResendConfirmationEmail")]
        [Authorize]
        public async Task<IActionResult> ResendConfirmationEmail()
        {
            var authenticatedUser = await GetAuthenticatedUserAccount();

            if (authenticatedUser == null)
                return BadRequest( new { Message = "Usuário não autenticado" } );

            if (authenticatedUser.EmailConfirmed)
                return BadRequest( new { Message = "Usuário com confirmação de email já realizada" } );

            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(authenticatedUser);
            var emailConfirmationUrl = Url.Link("ConfirmEmail", new { token = emailToken, email = authenticatedUser.Email });

            await _emailService.SendEmail(
                authenticatedUser.Email,
                "Peep - Confirmação de email",
                $"<html><body>Seja bem-vindo ao Peep! Clique <a href=\"{emailConfirmationUrl}\">aqui</a> para confirmar seu email e poder acessar a sua conta</body></html>");

            return Ok();
        }
    }
}

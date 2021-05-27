﻿using System;
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

        /* */
        [HttpPost]
        [Route("Email")]
        public IActionResult SendEmail([FromQuery] string email)
        {
            Task result =  _emailService.SendEmail(
                    email,
                    "Você recebeu um email!",
                    "Sim, isso mesmo. Isso é um email");

            if (result.IsCompleted)
                return Ok();
            return BadRequest();

        }
        /* */

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
                EmailConfirmed = false,
                PhoneNumberConfirmed = false

            };

            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (!result.Succeeded)
                return BadRequest( new { result.Errors } );

            if (user.Email != null)
            {
                SendConfirmationEmail(user);
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

            SendConfirmationEmail(authenticatedUser);

            return Ok();
        }

        private async void SendConfirmationEmail(ApplicationUser user)
        {
            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var emailConfirmationUrl = Url.Link("ConfirmEmail", new { token = emailToken, email = user.Email });

            await _emailService.SendEmail(
                user.Email,
                "Peep - Confirmação de email",
                $"<html><body>Seja bem-vindo ao Peep! Clique <a href=\"{emailConfirmationUrl}\">aqui</a> para confirmar seu email e poder acessar a sua conta</body></html>");
        }
    }
}

using System;
using System.Linq;
using System.Security.Claims;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SocialAccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;

        public SocialAccountsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailService emailService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Providers()
        {
            var authSchemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
            return Ok(authSchemes.Select(s => s.DisplayName).ToList());
        }

        [HttpGet]
        public IActionResult SignIn(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action("Callback", "SocialAccounts");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [HttpGet]
        public async Task<IActionResult> Callback(string returnUrl = null, string remoteError = null)
        {
            returnUrl ??= Url.Content("~/");

            if (remoteError != null)
                return RedirectToPage("./", new { ReturnUrl = returnUrl });
            
            var loginInfo = await _signInManager.GetExternalLoginInfoAsync();

            if (loginInfo == null)
                return RedirectToPage("./", new { ReturnUrl = returnUrl });

            var userEmail = loginInfo.Principal.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(userEmail))
            {
                return LocalRedirect(
                    $"{returnUrl}?message=Email scope access is required to add {loginInfo.ProviderDisplayName} provider&type=danger");
            }

            var login = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey,
                isPersistent: true, bypassTwoFactor: true);

            if (login.Succeeded)
                return LocalRedirect(returnUrl);
            return BadRequest();

        }
    }
}

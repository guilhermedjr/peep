namespace Peep.Wings.Application.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class SocialAccountsController : CustomControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IEmailService _emailService;
    private readonly IOAuthService<GoogleUserInfo> _googleService;
    private readonly IOAuthService<TwitterUserInfo> _twitterService;
    private readonly IOAuthService<GitHubUserInfo> _gitHubService;

    public SocialAccountsController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ITokenService tokenService,
        IEmailService emailService,
        IOAuthService<GoogleUserInfo> googleService,
        IOAuthService<TwitterUserInfo> twitterService,
        IOAuthService<GitHubUserInfo> gitHubService)
        : base(userManager)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._tokenService = tokenService;
        this._emailService = emailService;
        this._googleService = googleService;
        this._twitterService = twitterService;
        this._gitHubService = gitHubService;
    }

    [HttpGet]
    public async Task<IActionResult> Providers()
    {
        var authSchemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
        return Ok(authSchemes.Select(s => s.DisplayName).ToList());
    }

    [HttpGet]
    public IActionResult SignIn(string provider)
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
            return BadRequest();
            
        var loginInfo = await _signInManager.GetExternalLoginInfoAsync();

        if (loginInfo == null)
            return BadRequest();

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

        var user = await _userManager.FindByEmailAsync(userEmail);

        if (user != null)
        {
            if (!user.EmailConfirmed)
            {
                var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmExternalProvider", "SocialAccounts",
                    values: new
                    {
                        userId = user.Id,
                        code = emailToken,
                        loginProvider = loginInfo.LoginProvider,
                        providerDisplayName = loginInfo.ProviderDisplayName,
                        providerKey = loginInfo.ProviderKey
                    },
                    protocol: Request.Scheme);

                await _emailService.SendEmailAsync(
                    user.Email,
                    $"Peep - Confirme o login com {loginInfo.ProviderDisplayName}",
                    $"<html><body>Por favor, confirme a associação da sua conta {loginInfo.ProviderDisplayName} clicando <a href =\"{callbackUrl}\">aqui</a> para confirmar seu email.</body></html>");

                return LocalRedirect(
                    $"{returnUrl}?message=External account association with {loginInfo.ProviderDisplayName} is pending.Please check your email");
            }

            await _userManager.AddLoginAsync(user, loginInfo);

            await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey,
                isPersistent: true, bypassTwoFactor: true);

            return LocalRedirect(
                $"{returnUrl}?message={loginInfo.ProviderDisplayName} has been added successfully");
        }
        return BadRequest();

        // Account with email address doesn't exist: 
        // redirect to choose either to create a new social account or associate it with an existing account.

    }

    [HttpPost]
    public async override Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string email)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Email == email);

        var result = await _userManager.ConfirmEmailAsync(user, token);

        string uiUrl = result.Succeeded ? "emailConfirmado" : "emailInexistente";

        // TODO: Fazer integração no front-end: criar as telas de email confirmado/não confirmado
        // e redirecionar para a home em caso positivo

        return Redirect(uiUrl);
    }


    [HttpGet]
    public async Task<IActionResult> ConfirmExternalProvider(string userId, string code,
        string loginProvider, string providerDisplayName, string providerKey)
    {
        var user = await _userManager.FindByIdAsync(userId);

        var confirmationResult = await _userManager.ConfirmEmailAsync(user, code);

        if (!confirmationResult.Succeeded)
            return new LocalRedirectResult($"/?message={providerDisplayName} failed to associate&type=danger");

        var newLoginResult = await _userManager.AddLoginAsync(user,
            new ExternalLoginInfo(null, loginProvider, providerKey,
                providerDisplayName));

        if (!newLoginResult.Succeeded)
            return new LocalRedirectResult($"/?message={providerDisplayName} failed to associate&type=danger");
        return new LocalRedirectResult($"/?message={providerDisplayName} has been added successfully");
    }

    [HttpPost]
    public async Task<IActionResult> Associate([FromBody] AssociateExternalLoginDto associateExternalLoginDto)
    {
        associateExternalLoginDto.ProviderDisplayName = null;
        associateExternalLoginDto.ProviderKey = Guid.NewGuid().ToString();

        if (!associateExternalLoginDto.AssociateToExistingAccount)
        {
            var newUser = new ApplicationUser
            {
                Email = associateExternalLoginDto.Email,
                UserName = associateExternalLoginDto.Username,
                EmailConfirmed = false,
                JoinedAt = DateTime.Now,
                Name = null,
                BirthDate = null,
                Password = null
            };

            var createUserResult = await _userManager.CreateAsync(newUser);

            if (createUserResult.Succeeded)
            {
                var associateExternalLoginResult = await _userManager.AddLoginAsync(newUser,
                    new ExternalLoginInfo(null, associateExternalLoginDto.LoginProvider,
                        associateExternalLoginDto.ProviderKey, associateExternalLoginDto.ProviderDisplayName
                        ));

                if (associateExternalLoginResult.Succeeded)
                {
                    newUser.EmailConfirmed = true;

                    await _userManager.UpdateAsync(newUser);

                    await _signInManager.ExternalLoginSignInAsync(
                        associateExternalLoginDto.LoginProvider,
                        associateExternalLoginDto.ProviderKey,
                        true
                        );

                    var userView = new ApplicationUserViewModel
                    {
                        Id = newUser.Id,
                        Name = newUser.Name,
                        Username = newUser.UserName,
                        Email = newUser.Email,
                        AuthenticationMethod = associateExternalLoginDto.LoginProvider
                    };

                    Response.Cookies.Append("peep_token", _tokenService.GenerateJsonWebToken(newUser), new CookieOptions
                    {
                        HttpOnly = true,
                        IsEssential = true,
                        SameSite = SameSiteMode.Lax
                    });

                    return Ok(userView);
                }
            }
        }

        if (String.IsNullOrEmpty(associateExternalLoginDto.ExistingAccountEmail))
            return BadRequest();

        var user = await _userManager.FindByEmailAsync(associateExternalLoginDto.ExistingAccountEmail);

        if (user == null)
            return BadRequest( new { Message = "Não há conta existente com o email informado" });

        if (!user.EmailConfirmed)
            return BadRequest();

        var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var callbackUrl = Url.Action("ConfirmExternalProvider", "SocialAccounts",
                    values: new
                    {
                        userId = user.Id,
                        code = emailToken,
                        loginProvider = associateExternalLoginDto.LoginProvider,
                        providerDisplayName = associateExternalLoginDto.ProviderDisplayName,
                        providerKey = associateExternalLoginDto.ProviderKey
                    },
                    protocol: Request.Scheme);

        await _emailService.SendEmailAsync(
            user.Email,
            $"Peep - Confirme o login com {associateExternalLoginDto.ProviderDisplayName}",
            $"<html><body>Por favor, confirme a associação da sua conta {associateExternalLoginDto.ProviderDisplayName} clicando <a href =\"{callbackUrl}\">aqui</a> para confirmar seu email.</body></html>");

        return Ok( new { Message = "E-mail de confirmação enviado" });

    }

    [HttpGet]
    public async Task<IActionResult> Twitter(string username)
    {
        var twitterUserInfo = await _twitterService.RetrieveLoggedUserInformation(username);

        if (twitterUserInfo == null)
            return BadRequest();
        return Ok(twitterUserInfo);
    }

}


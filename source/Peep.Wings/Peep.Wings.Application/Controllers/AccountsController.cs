using Microsoft.AspNetCore.Authorization;

namespace Peep.Wings.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly CosmosDbConnection _cosmosDbConnection;

    private readonly IOAuthService<GoogleUserInfoDto> _googleService;

    public AccountsController(
        UserManager<ApplicationUser> userManager,
        CosmosDbConnection cosmosDbConnection,
        IOAuthService<GoogleUserInfoDto> googleService) 
    {
        _userManager = userManager;
        _cosmosDbConnection = cosmosDbConnection;
        _googleService = googleService;
    }

    [HttpPost]
    [Route("SignIn")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var userInfo = await _googleService.RetrieveLoggedUserInformation(loginDto.Token);
        var peepUser = await _userManager.FindByEmailAsync(userInfo.email);

        if (peepUser == null)
        {
            var user = new ApplicationUser
            {
                Email = userInfo.email,
                Name = userInfo.name,
                UserName = userInfo.email.Substring(0, userInfo.email.IndexOf("@")),
                BirthDate = new DateTime(2000, 01, 01),
                ProfileImageUrl = userInfo.picture,
                JoinedAt = DateTime.Now,
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(user);
            await _cosmosDbConnection.AddItemAsync<ApplicationUser>(user);
        }
        else
        {
            var user = new ApplicationUser
            {
                Email = userInfo.email,
                Name = userInfo.name,
                UserName = userInfo.email.Substring(0, userInfo.email.IndexOf("@")),
                BirthDate = new DateTime(2000, 01, 01),
                ProfileImageUrl = userInfo.picture,
                JoinedAt = peepUser.JoinedAt,
                EmailConfirmed = true
            };

            await _userManager.UpdateSecurityStampAsync(user);
            await _userManager.UpdateAsync(user);
            await _cosmosDbConnection.UpdateItemAsync<ApplicationUser>(user.Id, user);
        }

        peepUser = await _userManager.FindByEmailAsync(userInfo.email);

        var userView = new ApplicationUserViewModel(peepUser.Id, peepUser.Email, peepUser.Name,
            peepUser.UserName, peepUser.BirthDate, peepUser.ProfileImageUrl, peepUser.JoinedAt);

        return Ok(userView);
    }

    [HttpGet]
    [Route("{id}", Name = "GetById")]
    [Authorize]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        var peepUser = await _userManager.FindByIdAsync(id.ToString());

        if (peepUser == null)
            return NotFound();

        var userView = new ApplicationUserViewModel(peepUser.Id, peepUser.Email, peepUser.Name,
            peepUser.UserName, peepUser.BirthDate, peepUser.ProfileImageUrl, peepUser.JoinedAt);

        return Ok(userView);
    }
}


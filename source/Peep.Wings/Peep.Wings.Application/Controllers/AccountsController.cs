using Microsoft.AspNetCore.Authorization;

namespace Peep.Wings.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly ConnectionFactory _factory;
    private const string QUEUE_NAME = "wings_messages";

    private readonly IOAuthService<GoogleUserInfoDto> _googleService;
    private readonly IPeepParrotService _parrotService;
    private readonly IPeepStorkService _storkService;

    public AccountsController(
        UserManager<ApplicationUser> userManager,
        IOAuthService<GoogleUserInfoDto> googleService,
        IPeepParrotService parrotService,
        IPeepStorkService storkService) 
    {
        _factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        _userManager = userManager;
        _googleService = googleService;
        _parrotService = parrotService;
        _storkService = storkService;
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
                BirthDate = DateTime.MinValue,
                ProfileImageUrl = userInfo.picture,
                JoinedAt = DateTime.Now,
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(user);
        }
        else
        {
            var user = new ApplicationUser
            {
                Email = userInfo.email,
                Name = userInfo.name,
                UserName = userInfo.email.Substring(0, userInfo.email.IndexOf("@")),
                BirthDate = DateTime.MinValue,
                ProfileImageUrl = userInfo.picture,
                JoinedAt = peepUser.JoinedAt,
                EmailConfirmed = true
            };

            await _userManager.UpdateSecurityStampAsync(user);
            await _userManager.UpdateAsync(user);
        }

        peepUser = await _userManager.FindByEmailAsync(userInfo.email);

        var userView = new ApplicationUserViewModel(peepUser.Id, peepUser.Email, peepUser.Name,
            peepUser.UserName, peepUser.BirthDate, peepUser.ProfileImageUrl, peepUser.JoinedAt);

        Response.Cookies.Append("peep_token", loginDto.IdToken, new CookieOptions
        {
            HttpOnly = true,
            IsEssential = true,
            SameSite = SameSiteMode.Lax
        });

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

    [HttpPost]
    [Route("Logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("peep_token");
        return NoContent();
    }

    private async Task SyncAddedUser(ApplicationUser user)
    {
        var userToSync = new SyncUserDto
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Username = user.UserName,
            BirthDate = user.BirthDate,
            JoinedAt = user.JoinedAt
        };

        await _parrotService.AddUser(userToSync);
        await _storkService.AddUser(userToSync);
    }

    private async Task SyncUpdatedUser(ApplicationUser user)
    {
        var userToSync = new SyncUserDto
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Username = user.UserName,
            BirthDate = user.BirthDate,
            JoinedAt = user.JoinedAt
        };

        await _parrotService.UpdateUser(userToSync);
        await _storkService.UpdateUser(userToSync);
    }

    private AcceptedResult PostCreatedAccountMessage(ApplicationUserViewModel user)
    {
        using var connection = _factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: QUEUE_NAME,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var stringfiedMessage = JsonSerializer.Serialize(user);
        var bytesMessage = Encoding.UTF8.GetBytes(stringfiedMessage);

        channel.BasicPublish(
            exchange: "",
            routingKey: QUEUE_NAME,
            basicProperties: null,
            body: bytesMessage);

        return Accepted();
    }
}


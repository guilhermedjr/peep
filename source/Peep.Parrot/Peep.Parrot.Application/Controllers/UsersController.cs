using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos;
namespace Peep.Parrot.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly CosmosDbConnection _cosmosDbConnection;
    private readonly IConfiguration _config;

    public UsersController(IConfiguration config)
    {
        _config = config;
        var cosmosDbSection = _config.GetSection("CosmosDb");

        string databaseName = cosmosDbSection.GetSection("DatabaseName").Value;
        string containerName = "Users";
        string account = cosmosDbSection.GetSection("Account").Value;
        string key = cosmosDbSection.GetSection("Key").Value;

        CosmosClientOptions clientOptions = new()
        {
            SerializerOptions = new CosmosSerializationOptions
            { PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase }
        };

        CosmosClient client = new(account, key, clientOptions);

        _cosmosDbConnection = new(client, databaseName, containerName);
    }

    //[Authorize]
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        var user = await _cosmosDbConnection.GetItemAsync<ApplicationUser>(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }
}



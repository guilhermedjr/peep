using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;

namespace Peep.Parrot.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly CosmosDbConnection _cosmosDbConnection;
    private readonly AppDbContext _appDbContext;
    private readonly IConfiguration _config;
    private readonly IPeepsRepository _peepsRepository;

    public UsersController(
        AppDbContext appDbContext,
        IConfiguration config,
        IPeepsRepository peepsRepository
        )
    {
        _appDbContext = appDbContext;

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

        _peepsRepository = peepsRepository;
    }

    [Authorize]
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        var user = await _cosmosDbConnection.GetItemAsync<ApplicationUser>(id);

        if (user == null)
            return NotFound();

        var userPeeps = Enumerable.ToList(await _peepsRepository.GetUserPeeps(id));

        if (userPeeps.Count > 0)
        {
            foreach (var peep in userPeeps)
            {
                var normalizedPeep = await _appDbContext.Peep.FindAsync(peep.Id);
                peep.PublicationDate = normalizedPeep.PublicationDate;
                peep.PublicationTime = normalizedPeep.PublicationTime;
            }

            user.Peeps = userPeeps
                .OrderByDescending(p => p.PublicationDate).OrderByDescending(p => p.PublicationTime).ToList();
        }

        return Ok(user);
    }
}



using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Peep.Parrot.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly CosmosDbConnection _cosmosDbConnection;
    private readonly IConfiguration _config;

    public UsersRepository(IConfiguration config)
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

    public async Task<ApplicationUser> GetById(Guid id) =>
        await _cosmosDbConnection.GetItemAsync<ApplicationUser>(id);
}


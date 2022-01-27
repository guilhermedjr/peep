using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Peep.Parrot.Repositories;

public class CosmosUsersSearchRepository : ISearchRepository<ApplicationUser>
{
    private readonly CosmosDbConnection _cosmosDbConnection;
    private readonly IConfiguration _config;

    public CosmosUsersSearchRepository(IConfiguration config)
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

    public async Task<IEnumerable<ApplicationUser>> Search(string searchString)
    {
        var queryString = 
            $"SELECT * FROM Users u WHERE UPPER(u.username) LIKE '{searchString.ToUpper()}%' " +
            $"OR UPPER(u.name) LIKE '{searchString.ToUpper()}%' " +
            $"ORDER BY u.name";

        var users = await _cosmosDbConnection.GetItemsAsync<ApplicationUser>(queryString);
        return users;
    }
}


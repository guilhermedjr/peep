using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
namespace Peep.Parrot.Infrastructure.Data;

public class CosmosDbConnection
{
    private readonly Container _container;

    public CosmosDbConnection(
        CosmosClient dbClient,
        string databaseName,
        string containerName
        )
    {
        _container = dbClient.GetContainer(databaseName, containerName);
    }

    public async Task AddItemAsync<T>(T item)
    {
        await _container.CreateItemAsync<T>(item);
    }

    public async Task DeleteItemAsync<T>(Guid id)
    {
        await _container.DeleteItemAsync<T>(id.ToString(), new PartitionKey(id.ToString()));
    }

    public async Task<T> GetItemAsync<T>(Guid id)
    {
        try
        {
            ItemResponse<T> response = await _container.ReadItemAsync<T>(id.ToString(), new PartitionKey(id.ToString()));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return default;
        }
    }

    public async Task<IEnumerable<T>> GetItemsAsync<T>(string queryString)
    {
        var query = _container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
        List<T> results = new();

        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();

            results.AddRange(response.ToList());
        }

        return results;
    }

    public async Task UpdateItemAsync<T>(Guid id, T item)
    {
        await _container.UpsertItemAsync<T>(item, new PartitionKey(id.ToString()));
    }
}


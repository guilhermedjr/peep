using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
namespace Peep.Parrot.Infrastructure.Data;

public class CosmosDbConnection
{
    private Container _container;

    public CosmosDbConnection(
        CosmosClient dbClient,
        string databaseName,
        string containerName
        )
    {
        this._container = dbClient.GetContainer(databaseName, containerName);
    }
}


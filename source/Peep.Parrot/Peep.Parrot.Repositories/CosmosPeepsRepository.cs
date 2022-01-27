using Newtonsoft.Json;

namespace Peep.Parrot.Repositories;

public class CosmosPeepsRepository : IPeepsRepository
{
    private readonly AppDbContext _sqlDbContext;
    private readonly CosmosDbConnection _cosmosDbConnection;

    public CosmosPeepsRepository(
        AppDbContext sqlDbContext,
        CosmosDbConnection cosmosDbConnection
        )
    {
        _sqlDbContext = sqlDbContext;
        _cosmosDbConnection = cosmosDbConnection;
    }

    public Task<Domain.Entities.Peep> AddPeep(Domain.Entities.Peep peep)
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.Entities.Peep> GetById(Guid id)
    {
        var peep = await _cosmosDbConnection.GetItemAsync<Domain.Entities.Peep>(id);
        return peep;
    }

    public async Task<IEnumerable<Domain.Entities.Peep>> GetUserPeeps(Guid userId)
    {
        var queryString = 
            $"SELECT * FROM Peeps p WHERE p.userId = '{userId.ToString().ToUpper()}'";

        var peeps = await _cosmosDbConnection.GetItemsAsync<Domain.Entities.Peep>(queryString);
        return peeps;
    }
}


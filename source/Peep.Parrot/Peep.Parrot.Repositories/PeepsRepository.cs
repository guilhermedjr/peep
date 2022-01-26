using Newtonsoft.Json;

namespace Peep.Parrot.Repositories;

public class PeepsRepository : IPeepsRepository
{
    private readonly AppDbContext _sqlDbContext;
    private readonly CosmosDbConnection _cosmosDbConnection;

    public PeepsRepository(
        AppDbContext sqlDbContext,
        CosmosDbConnection cosmosDbConnection
        )
    {
        _sqlDbContext = sqlDbContext;
        _cosmosDbConnection = cosmosDbConnection;
    }

    public Task AddPeep(AddPeepDto addPeepDto)
    {
        throw new NotImplementedException();
    }

    /*public async Task AddPeep(AddPeepDto addPeepDto)
    {
        var peep = new Domain.Entities.Peep(addPeepDto.UserId, addPeepDto.TextContent, 0, 0);

        _sqlDbContext.Peep.Add(peep);
        _sqlDbContext.SaveChanges();

        await _cosmosDbConnection.AddItemAsync<Domain.Entities.Peep>(peep);
    }*/

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


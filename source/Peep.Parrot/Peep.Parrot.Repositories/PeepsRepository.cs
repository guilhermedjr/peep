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

    public async Task AddPeep(AddPeepDto addPeepDto)
    {
        var peep = new Domain.Entities.Peep(addPeepDto.UserId, addPeepDto.TextContent, 0, 0);

        _sqlDbContext.Peep.Add(peep);
        _sqlDbContext.SaveChanges();

        await _cosmosDbConnection.AddItemAsync<Domain.Entities.Peep>(peep);
    }

    /*public async Task<Domain.Entities.Peep> GetPeep(Guid id)
    {
        var queryString = $"SELECT * FROM Peeps p WHERE p.id = {id}";
        var peep = await _cosmosDbConnection.GetItemAsync<Domain.Entities.Peep>(queryString);
        return peep;
    }*/

    public async Task DeletePeep(Domain.Entities.Peep peep)
    {
        _sqlDbContext.Peep.Remove(peep);
        _sqlDbContext.SaveChanges();

        await _cosmosDbConnection.DeleteItemAsync<Domain.Entities.Peep>(peep.Id);
    }

    public Task<Domain.Entities.Peep> GetPeep(Guid id)
    {
        throw new NotImplementedException();
    }
}


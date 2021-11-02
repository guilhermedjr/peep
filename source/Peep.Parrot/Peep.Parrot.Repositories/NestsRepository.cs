using Peep.Parrot.Domain.Entities;

namespace Peep.Parrot.Repositories;

public class NestsRepository : INestsRepository
{
    private readonly RedisDbConnection _redisDbConnection;

    public NestsRepository(RedisDbConnection redisDbConnection)
    {
        this._redisDbConnection = redisDbConnection;
    }

    public Task AddNest(AddNestDto addNestDto)
    {
        throw new NotImplementedException();
    }

    public Task AddNestMembers(Guid nestId, IEnumerable<User> members)
    {
        throw new NotImplementedException();
    }

    public Task DeleteNest(Guid ownerId, Guid nestId)
    {
        throw new NotImplementedException();
    }

    public Task EditNest(EditNestDto editNestDto)
    {
        throw new NotImplementedException();
    }
}


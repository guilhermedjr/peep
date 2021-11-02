namespace Peep.Parrot.Repositories;

public class PeepsRepository : IPeepsRepository
{
    private readonly RedisDbConnection _redisDbConnection;

    public PeepsRepository(RedisDbConnection redisDbConnection)
    {
        this._redisDbConnection = redisDbConnection;
    }

    public async Task <bool> AddPeep(AddPeepDto addPeepDto)
    {
        var now = DateTime.Now;
        var peepId = Guid.NewGuid();

        addPeepDto.PeepId = peepId;
        addPeepDto.Date = now.Date;
        addPeepDto.Time = now.TimeOfDay;

        if (_redisDbConnection.CreateHash<AddPeepDto>($"peep:{peepId}", addPeepDto))
        {
            return await _redisDbConnection.AddGuidOnSet($"peeps_user:{addPeepDto.UserId}", peepId);
        }
        return false;
    }
            
    public async Task<bool> EditPeep(EditPeepDto editPeepDto)
    {
        if (_redisDbConnection.GetObjectFromKey<EditPeepDto>($"peep:{editPeepDto.PeepId}") != null)
        {
            if (await _redisDbConnection.GuidIsOnSet($"peeps_user:{editPeepDto.UserId}", editPeepDto.PeepId))
            {
                return _redisDbConnection.UpdateHashFromKey<EditPeepDto>($"peep:{editPeepDto.PeepId}", editPeepDto);
            }
            return false;
        }
        return false;
    }
       
    public async Task<bool> DeletePeep(Guid userId, Guid peepId)
    {
        if (await _redisDbConnection.DeleteGuidOfSet($"peeps_user:{userId}", peepId))
        {
            return await _redisDbConnection.DeleteKey($"peep:{peepId}");
        }
        return false;
    }
}


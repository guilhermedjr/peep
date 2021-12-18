namespace Peep.Parrot.Domain.Repository;

public interface IPeepsRepository
{
    Task AddPeep(AddPeepDto addPeepDto);
    Task<Entities.Peep> GetPeep(Guid id);
    Task<IEnumerable<Entities.Peep>> GetUserPeeps(Guid userId);
}


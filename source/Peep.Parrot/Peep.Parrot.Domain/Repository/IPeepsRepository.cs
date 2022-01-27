namespace Peep.Parrot.Domain.Repository;

public interface IPeepsRepository
{
    Task<Entities.Peep> AddPeep(Entities.Peep peep);
    Task<Entities.Peep> GetById(Guid id);
    Task<IEnumerable<Entities.Peep>> GetUserPeeps(Guid userId);
}


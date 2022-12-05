namespace Peep.Parrot.Domain.Repository;

public interface IPeepsRepository
{
    Task<Entities.Peep> AddPeep(Entities.Peep peep);
    Task<Entities.Peep> GetById(Guid id);
    Task<Entities.Peep> UpdatePeep(Entities.Peep peep);
    Task DeletePeep(Guid id);
}


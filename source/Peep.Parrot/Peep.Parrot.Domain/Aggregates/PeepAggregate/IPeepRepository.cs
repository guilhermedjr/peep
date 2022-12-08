using Peep.Parrot.Domain.SeedWork;
namespace Peep.Parrot.Domain.Aggregates.PeepAggregate;

public interface IPeepsRepository
{
    Task<Peep> AddPeep(Peep peep);
    Task<Peep> GetById(Guid id);
    Task<Peep> UpdatePeep(Peep peep);
    Task DeletePeep(Guid id);
}

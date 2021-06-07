using System;
using System.Threading.Tasks;
using Peep.Parrot.Domain.Dtos;

namespace Peep.Parrot.Domain.Repository
{
    public interface IPeepsRepository
    {
        Task AddPeep(AddPeepDto addPeepDto);
        Task EditPeep(Guid userId, EditPeepDto editPeepDto);
        Task DeletePeep(Guid userId, Guid peepId);
    }
}

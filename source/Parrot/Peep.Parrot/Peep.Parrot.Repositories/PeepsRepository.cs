using System;
using System.Threading.Tasks;
using Peep.Parrot.Domain.Dtos;
using Peep.Parrot.Domain.Repository;

namespace Peep.Parrot.Repositories
{
    public class PeepsRepository : IPeepsRepository
    {
        public Task AddPeep(AddPeepDto addPeepDto)
        {
            throw new NotImplementedException();
        }

        public Task EditPeep(Guid userId, EditPeepDto editPeepDto)
        {
            throw new NotImplementedException();
        }

        public Task DeletePeep(Guid userId, Guid peepId)
        {
            throw new NotImplementedException();
        }
    }
}

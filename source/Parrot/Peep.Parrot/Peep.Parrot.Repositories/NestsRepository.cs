using Peep.Parrot.Domain.Dtos;
using Peep.Parrot.Domain.Entities;
using Peep.Parrot.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Peep.Parrot.Repositories
{
    public class NestsRepository : INestsRepository
    {
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
}

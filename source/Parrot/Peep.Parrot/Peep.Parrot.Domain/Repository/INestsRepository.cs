using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Peep.Parrot.Domain.Dtos;
using Peep.Parrot.Domain.Entities;

namespace Peep.Parrot.Domain.Repository
{
    public interface INestsRepository
    {
        Task AddNest(AddNestDto addNestDto);
        Task EditNest(EditNestDto editNestDto);
        Task AddNestMembers(Guid nestId, IEnumerable<User> members);
        Task DeleteNest(Guid ownerId, Guid nestId);
    }
}

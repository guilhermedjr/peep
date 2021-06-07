using System;
using System.Threading.Tasks;

namespace Peep.Parrot.Domain.Repository
{
    public interface IUsersConnectionsRepository
    {
        Task AddFollowUp(Guid followerId, Guid followedId);
        Task RemoveFollowUp(Guid followerId, Guid followedId);
    }
}

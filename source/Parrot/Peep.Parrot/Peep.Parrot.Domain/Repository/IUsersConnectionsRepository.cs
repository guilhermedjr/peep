using System;
using System.Threading.Tasks;

namespace Peep.Parrot.Domain.Repository
{
    public interface IUsersConnectionsRepository
    {
        Task RequestFollowUp(Guid requestingUserId, Guid requestedUserId);
        Task GetUserFollowRequests(Guid userId);
        Task AddFollowUp(Guid followerId, Guid followedId);
        Task RemoveFollowUp(Guid followerId, Guid followedId);
    }
}

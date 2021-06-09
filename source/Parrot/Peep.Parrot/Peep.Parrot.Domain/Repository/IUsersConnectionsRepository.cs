using System;
using System.Threading.Tasks;

namespace Peep.Parrot.Domain.Repository
{
    public interface IUsersConnectionsRepository
    {
        Task<bool> RequestFollowUp(Guid requestingUserId, Guid requestedUserId);
        Task<bool> RemoveFollowUpRequest(Guid requestingUserId, Guid requestedUserId);
        Task<bool> AddFollowUp(Guid followerId, Guid followedId);
        Task<bool> RemoveFollowUp(Guid followerId, Guid followedId);
        Task GetUserFollowRequests(Guid userId);
    }
}

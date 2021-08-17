using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Peep.Parrot.Domain.Repository
{
    public interface IUsersConnectionsRepository
    {
        Task<bool> RequestFollowUp(Guid requestingUserId, Guid requestedUserId);
        Task<bool> RemoveFollowUpRequest(Guid requestingUserId, Guid requestedUserId);
        Task<List<Guid>> GetUserFollowUpRequests(Guid userId);

        Task<bool> AddFollowUp(Guid followerId, Guid followedId);
        Task<bool> RemoveFollowUp(Guid followerId, Guid followedId);

        Task<bool> ConnectionExists(Guid followerId, Guid followedId);
        Task<bool> RemoveConnectionAsync(Guid followedId, Guid followerId);
        
    }
}

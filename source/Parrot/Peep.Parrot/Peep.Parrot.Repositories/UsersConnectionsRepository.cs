using Microsoft.Extensions.Configuration;
using Peep.Parrot.Domain.Repository;
using Peep.Parrot.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Peep.Parrot.Repositories
{
    public class UsersConnectionsRepository : RedisDbConnection, IUsersConnectionsRepository
    {
        public UsersConnectionsRepository(IConfiguration config) : base(config) { }

        public async Task<bool> RequestFollowUp(Guid requestingUserId, Guid requestedUserId)
        {
            if (!await FollowUpRequestExistsAsync(requestingUserId, requestedUserId))
                return await base.AddGuidOnSet($"followupRequests_user:{requestedUserId}", requestingUserId);
            return false;
        }

        public async Task<bool> RemoveFollowUpRequest(Guid requestingUserId, Guid requestedUserId)
        {
            if (await FollowUpRequestExistsAsync(requestingUserId, requestedUserId))
                return await this.RemoveFollowUpRequestAsync(requestingUserId, requestedUserId);
            return false;
        }

        public async Task<List<Guid>> GetUserFollowUpRequests(Guid userId) =>
            await base.GetAllGuidSetMembers($"followupRequests_user:{userId}");
        

        public async Task<bool> AddFollowUp(Guid followerId, Guid followedId)
        {
            if (!await ConnectionExists(followerId, followedId))
            {
                if (await FollowUpRequestExistsAsync(followerId, followedId))
                {
                    if (await RemoveFollowUpRequestAsync(followerId, followedId))
                    {
                        if (await base.AddGuidOnSet($"followers_user:{followedId}", followerId))
                            return await base.AddGuidOnSet($"following_user:{followerId}", followedId);
                        return false;
                    }
                       
                    return false;
                }

                else if (await base.AddGuidOnSet($"followers_user:{followedId}", followerId))
                    return await base.AddGuidOnSet($"following_user:{followerId}", followedId);
                return false;
            }

            return false;
        }

        public async Task<bool> RemoveFollowUp(Guid followerId, Guid followedId)
        {
            if (await ConnectionExists(followerId, followedId))
                return await this.RemoveConnectionAsync(followedId, followerId);
            return false;
        }

        private async Task<bool> FollowUpRequestExistsAsync(Guid requestingUserId, Guid requestedUserId) =>
            await base.GuidIsOnSet($"followupRequests_user:{requestedUserId}", requestingUserId);

        private async Task<bool> RemoveFollowUpRequestAsync(Guid requestingUserId, Guid requestedUserId) =>
            await base.DeleteGuidOfSet($"followupRequests_user:{requestedUserId}", requestingUserId);

        public async Task<bool> ConnectionExists(Guid followerId, Guid followedId) =>
            await base.GuidIsOnSet($"followers_user:{followedId}", followerId);

        public async Task<bool> RemoveConnectionAsync(Guid followedId, Guid followerId)
        {
            if (await base.DeleteGuidOfSet($"followers_user:{followedId}", followerId))
                return await base.DeleteGuidOfSet($"following_user:{followerId}", followedId);
            return false;
        }

        
    }
}

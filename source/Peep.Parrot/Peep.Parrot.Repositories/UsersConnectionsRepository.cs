using Peep.Parrot.Domain.Repository;
using Peep.Parrot.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Peep.Parrot.Repositories
{
    public class UsersConnectionsRepository : IUsersConnectionsRepository
    {
        private readonly RedisDbConnection _redisDbConnection;

        public UsersConnectionsRepository(RedisDbConnection redisDbConnection)
        {
            this._redisDbConnection = redisDbConnection;
        }

        public async Task<bool> RequestFollowUp(Guid requestingUserId, Guid requestedUserId)
        {
            if (!await FollowUpRequestExistsAsync(requestingUserId, requestedUserId))
                return await _redisDbConnection.AddGuidOnSet($"followupRequests_user:{requestedUserId}", requestingUserId);
            return false;
        }

        public async Task<bool> RemoveFollowUpRequest(Guid requestingUserId, Guid requestedUserId)
        {
            if (await FollowUpRequestExistsAsync(requestingUserId, requestedUserId))
                return await this.RemoveFollowUpRequestAsync(requestingUserId, requestedUserId);
            return false;
        }

        public async Task<List<Guid>> GetUserFollowUpRequests(Guid userId) =>
            await _redisDbConnection.GetAllGuidSetMembers($"followupRequests_user:{userId}");
        

        public async Task<bool> AddFollowUp(Guid followerId, Guid followedId)
        {
            if (!await ConnectionExists(followerId, followedId))
            {
                if (await FollowUpRequestExistsAsync(followerId, followedId))
                {
                    if (await RemoveFollowUpRequestAsync(followerId, followedId))
                    {
                        if (await _redisDbConnection.AddGuidOnSet($"followers_user:{followedId}", followerId))
                            return await _redisDbConnection.AddGuidOnSet($"following_user:{followerId}", followedId);
                        return false;
                    }
                       
                    return false;
                }

                else if (await _redisDbConnection.AddGuidOnSet($"followers_user:{followedId}", followerId))
                    return await _redisDbConnection.AddGuidOnSet($"following_user:{followerId}", followedId);
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
            await _redisDbConnection.GuidIsOnSet($"followupRequests_user:{requestedUserId}", requestingUserId);

        private async Task<bool> RemoveFollowUpRequestAsync(Guid requestingUserId, Guid requestedUserId) =>
            await _redisDbConnection.DeleteGuidOfSet($"followupRequests_user:{requestedUserId}", requestingUserId);

        public async Task<bool> ConnectionExists(Guid followerId, Guid followedId) =>
            await _redisDbConnection.GuidIsOnSet($"followers_user:{followedId}", followerId);

        public async Task<bool> RemoveConnectionAsync(Guid followedId, Guid followerId)
        {
            if (await _redisDbConnection.DeleteGuidOfSet($"followers_user:{followedId}", followerId))
                return await _redisDbConnection.DeleteGuidOfSet($"following_user:{followerId}", followedId);
            return false;
        }

        
    }
}

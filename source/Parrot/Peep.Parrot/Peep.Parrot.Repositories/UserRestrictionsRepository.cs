using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peep.Parrot.Domain.Repository;
using Peep.Parrot.Infrastructure.Data;

namespace Peep.Parrot.Repositories
{
    public class UserRestrictionsRepository : RedisDbConnection, IUserRestrictionsRepository
    {
        private readonly 
            IUsersConnectionsRepository _usersConnectionsRepository;

        public UserRestrictionsRepository(
            IConfiguration config,
            IUsersConnectionsRepository usersConnectionsRepository
            ): base(config) 
        {
            this._usersConnectionsRepository = usersConnectionsRepository;
        }

        public async Task<bool> MuteUser(Guid mufflerId, Guid mutedUserId)
        {
            if (!await base.GuidIsOnSet($"muted_user:{mufflerId}", mutedUserId))
                return await base.AddGuidOnSet($"muted_user:{mufflerId}", mutedUserId);
            return false;
        }

        public async Task<bool> BlockUser(Guid blockingUserId, Guid blockedUserId)
        {
            if (!await BlockageExistsAsync(blockingUserId, blockedUserId))
            {
                if (await BlockedUserFollowsBlockingUserAsync(blockedUserId, blockingUserId))
                {
                    if (await RemoveFollowAsync(blockedUserId, blockingUserId))
                    {
                        if (await BlockingUserFollowsBlockedUserAsync(blockingUserId, blockedUserId))
                        {
                            if (await RemoveFollowAsync(blockingUserId, blockedUserId))
                                return await this.BlockUserAsync(blockingUserId, blockedUserId);
                            return false;
                        }
                        return await this.BlockUserAsync(blockingUserId, blockedUserId);
                    }
                    return false;
                }

                else if (await BlockingUserFollowsBlockedUserAsync(blockingUserId, blockedUserId))
                {
                    if (await RemoveFollowAsync(blockingUserId, blockedUserId))
                        return await this.BlockUserAsync(blockingUserId, blockedUserId);
                    return false;
                }

                else 
                    return await this.BlockUserAsync(blockingUserId, blockedUserId);
            }
            return false;
        }

        public async Task<bool> UnmuteUser(Guid mufflerId, Guid mutedUserId)
        {
            if (await base.GuidIsOnSet($"muted_user:{mufflerId}", mutedUserId))
                return await base.DeleteGuidOfSet($"muted_user:{mufflerId}", mutedUserId);
            return false;
        }

        public async Task<bool> UnblockUser(Guid blockingUserId, Guid blockedUserId)
        {
            if (await BlockageExistsAsync(blockingUserId, blockedUserId))
                return await base.DeleteGuidOfSet($"blocked_user:{blockingUserId}", blockedUserId);
            return false;
        }

        public async void ChangeAccountVisibility(Guid userId)
        {
            bool accountVisibility = await base.GetBooleanValueOfHashField($"user:{userId}", "IsPrivateAccount");
            base.SetValueOfHashField<bool>($"user:{userId}", "IsPrivateAccount", !accountVisibility);
        }

        private async Task<bool> BlockageExistsAsync(Guid blockingUserId, Guid blockedUserId) =>
            await base.GuidIsOnSet($"blocked_user:{blockingUserId}", blockedUserId);

        private async Task<bool> BlockedUserFollowsBlockingUserAsync(Guid blockedUserId, Guid blockingUserId) =>
            await _usersConnectionsRepository.ConnectionExists(blockedUserId, blockingUserId);

        private async Task<bool> BlockingUserFollowsBlockedUserAsync(Guid blockingUserId, Guid blockedUserId) =>
            await _usersConnectionsRepository.ConnectionExists(blockingUserId, blockedUserId);

        private async Task<bool> RemoveFollowAsync(Guid followerId, Guid followedId) =>
            await _usersConnectionsRepository.RemoveConnectionAsync(followerId, followedId);

        private async Task<bool> BlockUserAsync(Guid blockingUserId, Guid blockedUserId) =>
           await base.AddGuidOnSet($"blocked_user:{blockingUserId}", blockedUserId);
    }
}

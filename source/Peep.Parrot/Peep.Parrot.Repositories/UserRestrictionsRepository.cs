namespace Peep.Parrot.Repositories;

public class UserRestrictionsRepository : IUserRestrictionsRepository
{
    private readonly RedisDbConnection _redisDbConnection;
    private readonly IUsersConnectionsRepository _usersConnectionsRepository;

    public UserRestrictionsRepository(
        RedisDbConnection redisDbConnection,
        IUsersConnectionsRepository usersConnectionsRepository
        )
    {
        this._redisDbConnection = redisDbConnection;
        this._usersConnectionsRepository = usersConnectionsRepository;
    }

    public async Task<bool> MuteUser(Guid mufflerId, Guid mutedUserId)
    {
        if (!await _redisDbConnection.GuidIsOnSet($"muted_user:{mufflerId}", mutedUserId))
            return await _redisDbConnection.AddGuidOnSet($"muted_user:{mufflerId}", mutedUserId);
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
        if (await _redisDbConnection.GuidIsOnSet($"muted_user:{mufflerId}", mutedUserId))
            return await _redisDbConnection.DeleteGuidOfSet($"muted_user:{mufflerId}", mutedUserId);
        return false;
    }

    public async Task<bool> UnblockUser(Guid blockingUserId, Guid blockedUserId)
    {
        if (await BlockageExistsAsync(blockingUserId, blockedUserId))
            return await _redisDbConnection.DeleteGuidOfSet($"blocked_user:{blockingUserId}", blockedUserId);
        return false;
    }

    public async void ChangeAccountVisibility(Guid userId)
    {
        bool accountVisibility = await _redisDbConnection.GetBooleanValueOfHashField($"user:{userId}", "IsPrivateAccount");
        _redisDbConnection.SetValueOfHashField<bool>($"user:{userId}", "IsPrivateAccount", !accountVisibility);
    }

    private async Task<bool> BlockageExistsAsync(Guid blockingUserId, Guid blockedUserId) =>
        await _redisDbConnection.GuidIsOnSet($"blocked_user:{blockingUserId}", blockedUserId);

    private async Task<bool> BlockedUserFollowsBlockingUserAsync(Guid blockedUserId, Guid blockingUserId) =>
        await _usersConnectionsRepository.ConnectionExists(blockedUserId, blockingUserId);

    private async Task<bool> BlockingUserFollowsBlockedUserAsync(Guid blockingUserId, Guid blockedUserId) =>
        await _usersConnectionsRepository.ConnectionExists(blockingUserId, blockedUserId);

    private async Task<bool> RemoveFollowAsync(Guid followerId, Guid followedId) =>
        await _usersConnectionsRepository.RemoveConnectionAsync(followerId, followedId);

    private async Task<bool> BlockUserAsync(Guid blockingUserId, Guid blockedUserId) =>
        await _redisDbConnection.AddGuidOnSet($"blocked_user:{blockingUserId}", blockedUserId);
}


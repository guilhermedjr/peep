namespace Peep.Parrot.Domain.Repository;

public interface IUserRestrictionsRepository
{
    void ChangeAccountVisibility(Guid userId);
    Task<bool> MuteUser(Guid mufflerId, Guid mutedUserId);
    Task<bool> BlockUser(Guid blockingUserId, Guid blockedUserId);
    Task<bool> UnmuteUser(Guid mufflerId, Guid mutedUserId);
    Task<bool> UnblockUser(Guid blockingUserId, Guid blockedUserId);
}


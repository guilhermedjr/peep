namespace Peep.Parrot.Domain.Entities;

public class Block
{
    public readonly Guid BlockerId;
    public readonly ApplicationUser Blocker;
    public readonly Guid BlockedId;
    public readonly ApplicationUser Blocked;
}


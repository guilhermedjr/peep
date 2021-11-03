namespace Peep.Parrot.Domain.Entities;

public class Block
{
    public readonly Guid BlockerId;
    public readonly User Blocker;
    public readonly Guid BlockedId;
    public readonly User Blocked;
}


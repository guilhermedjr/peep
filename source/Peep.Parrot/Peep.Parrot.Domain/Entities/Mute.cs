namespace Peep.Parrot.Domain.Entities;

public class Mute
{
    public readonly Guid MuterId;
    public readonly ApplicationUser Muter;
    public readonly Guid MutedId;
    public readonly ApplicationUser Muted;
}


namespace Peep.Parrot.Domain.Entities;

public class Mute
{
    public readonly Guid MuterId;
    public readonly User Muter;
    public readonly Guid MutedId;
    public readonly User Muted;
}


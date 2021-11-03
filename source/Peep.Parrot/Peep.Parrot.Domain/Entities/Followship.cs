namespace Peep.Parrot.Domain.Entities;

public class Followship
{
    public readonly Guid FollowerId;
    public readonly User Follower;
    public readonly Guid FollowedId;
    public readonly User Followed;
    public bool Accepted { get; private set; }

    public void Accept() => Accepted = true;
}


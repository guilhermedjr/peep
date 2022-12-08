using Peep.Parrot.Domain.SeedWork;
namespace Peep.Parrot.Domain.Aggregates.PeepAggregate;

public class PeepRepost : ValueObject
{
    public PeepRepost(Guid peepId, Guid userId)
    {
        PeepId = peepId;
        UserId = userId;
        DateTime = DateTime.UtcNow;
    }

    public Guid PeepId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime DateTime { get; private set; }
}

public class PeepDisrepost : ValueObject
{
    public PeepDisrepost(Guid peepId, Guid userId)
    {
        PeepId = peepId;
        UserId = userId;
        DateTime = DateTime.UtcNow;
    }

    public Guid PeepId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime DateTime { get; private set; }
}

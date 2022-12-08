using Peep.Parrot.Domain.SeedWork;
namespace Peep.Parrot.Domain.Aggregates.PeepAggregate;

public class PeepLike : ValueObject
{
    public PeepLike(Guid peepId, Guid userId)
    {
        PeepId = peepId;
        UserId = userId;
        DateTime = DateTime.UtcNow;
    }

    public Guid PeepId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime DateTime { get; private set; }
}

public class PeepDislike : ValueObject
{
    public PeepDislike(Guid peepId, Guid userId)
    {
        PeepId = peepId;
        UserId = userId;
        DateTime = DateTime.UtcNow;
    }

    public Guid PeepId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime DateTime { get; private set; }
}

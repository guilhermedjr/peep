using Peep.Parrot.Domain.SeedWork;
namespace Peep.Parrot.Domain.Aggregates.PeepAggregate;

public class PeepVersionSnapshot : ValueObject
{
    public PeepVersionSnapshot(Guid peepId, PeepContent peepContent, DateOnly snapshotDate, TimeOnly snapshotTime, IReadOnlyCollection<PeepLike> likes, IReadOnlyCollection<Peep> replies, IReadOnlyCollection<Peep> quotes, IReadOnlyCollection<PeepRepost> rps)
    {
        PeepId = peepId;
        PeepContent = peepContent;
        SnapshotDate = snapshotDate;
        SnapshotTime = snapshotTime;
        Likes = likes;
        Replies = replies;
        Quotes = quotes;
        Rps = rps;
    }

    public Guid PeepId { get; private set; }
    public PeepContent PeepContent { get; private set; }
    public DateOnly SnapshotDate { get; private set; }
    public TimeOnly SnapshotTime { get; private set; }
    public IReadOnlyCollection<PeepLike> Likes { get; private set; }
    public IReadOnlyCollection<Peep> Replies { get; private set; } 
    public IReadOnlyCollection<Peep> Quotes { get; private set; }
    public IReadOnlyCollection<PeepRepost> Rps { get; private set; }
}

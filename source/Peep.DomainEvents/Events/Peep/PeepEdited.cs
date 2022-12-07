using Peep.EventBus;
namespace Peep.DomainEvents.Events.Peep;

public class PeepEdited : Event
{
    public PeepEdited(Guid peepId, object peepNewContent, DateOnly editionDate, TimeOnly editionTime)
    {
        PeepId = peepId;
        PeepNewContent = peepNewContent;
        EditionDate = editionDate;
        EditionTime = editionTime;
    }

    public Guid PeepId { get; init; }
    public object PeepNewContent { get; init; }
    //public PeepVersionSnapshot PeepLastEditedVersion { get; init; }

    public DateOnly EditionDate { get; init; }
    public TimeOnly EditionTime { get; init; }
}

/*public record PeepVersionSnapshot(Guid PeepId, PeepContent PeepContent, DateOnly SnapshotDate, TimeOnly SnapshotTime,
        Dictionary<Guid, DateTime> Likes, IReadOnlyCollection<Guid> Replies, IReadOnlyCollection<Guid> Quotes, Dictionary<Guid, DateTime> Rps);*/

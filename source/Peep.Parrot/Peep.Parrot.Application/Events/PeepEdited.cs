using Peep.EventBus.Events;
using Peep.Parrot.Domain.ValueObjects;
namespace Peep.Parrot.Application.Events;

public class PeepEdited : Event
{
    public PeepEdited(Guid peepId, PeepContent peepNewContent, PeepVersionSnapshot peepLastEditedVersion, DateOnly editionDate, TimeOnly editionTime)
    {
        PeepId = peepId;
        PeepNewContent = peepNewContent;
        PeepLastEditedVersion = peepLastEditedVersion;
        EditionDate = editionDate;
        EditionTime = editionTime;
    }

    public Guid PeepId { get; init; }
    public PeepContent PeepNewContent { get; init; }
    public PeepVersionSnapshot PeepLastEditedVersion { get; init; }

    public DateOnly EditionDate { get; init; }
    public TimeOnly EditionTime { get; init; }
}

using Peep.EventBus.Events;
namespace Peep.Parrot.Application.Events;

public class PeepDisliked : Event
{
    public PeepDisliked(Guid userId, Guid peepId)
    {
        UserId = userId;
        PeepId = peepId;
    }

    public Guid UserId { get; init; }
    public Guid PeepId { get; init; }
}

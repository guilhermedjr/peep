using Peep.EventBus;
namespace Peep.DomainEvents.Events.InstantInteractions;

public class PeepLiked : Event
{
    public PeepLiked(Guid userId, Guid peepId)
    {
        UserId = userId;
        PeepId = peepId;
    }

    public Guid UserId { get; init; }
    public Guid PeepId { get; init; }
}
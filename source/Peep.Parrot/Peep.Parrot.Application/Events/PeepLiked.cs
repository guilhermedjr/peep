using Peep.EventBus.Events;
namespace Peep.Parrot.Application.Events;

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

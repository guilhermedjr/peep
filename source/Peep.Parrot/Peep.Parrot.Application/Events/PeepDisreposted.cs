using Peep.EventBus.Events;
namespace Peep.Parrot.Application.Events;

public class PeepDisreposted : Event
{
    public PeepDisreposted(Guid userId, Guid peepId)
    {
        UserId = userId;
        PeepId = peepId;
    }

    public Guid UserId { get; init; }
    public Guid PeepId { get; init; }
}

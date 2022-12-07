using Peep.EventBus;
namespace Peep.DomainEvents.Events.Peep;

public class PeepRemoved : Event
{
    public PeepRemoved(Guid peepId)
    {
        PeepId = peepId;
    }

    public Guid PeepId { get; init; }
}

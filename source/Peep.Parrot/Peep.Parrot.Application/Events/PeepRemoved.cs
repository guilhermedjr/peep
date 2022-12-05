using Peep.EventBus.Events;
namespace Peep.Parrot.Application.Events;

public class PeepRemoved : Event
{
	public PeepRemoved(Guid peepId)
	{
		PeepId = peepId;
	}

    public Guid PeepId { get; init; }
}

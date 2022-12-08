using Peep.EventBus;
namespace Peep.Parrot.Application.Events;

public class PeepReplyRemoved : Event
{
    public PeepReplyRemoved(Guid repliedPeepId, Domain.Aggregates.PeepAggregate.Peep reply)
    {
        RepliedPeepId = repliedPeepId;
        Reply = reply;
    }

    public Guid RepliedPeepId { get; init; }
    public Domain.Aggregates.PeepAggregate.Peep Reply { get; init; }
}

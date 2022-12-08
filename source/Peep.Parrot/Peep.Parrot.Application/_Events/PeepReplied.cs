using Peep.EventBus;
namespace Peep.Parrot.Application.Events;

public class PeepReplied : Event
{
    public PeepReplied(Guid repliedPeepId, Domain.Aggregates.PeepAggregate.Peep reply)
    {
        RepliedPeepId = repliedPeepId;
        Reply = reply;
    }

    public Guid RepliedPeepId { get; init; }
    public Domain.Aggregates.PeepAggregate.Peep Reply { get; init; }
}


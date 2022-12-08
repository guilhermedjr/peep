using Peep.EventBus;
namespace Peep.Parrot.Application.Events;

public class PeepQuoted : Event
{
    public PeepQuoted(Guid quotedPeepId, Domain.Aggregates.PeepAggregate.Peep quote)
    {
        QuotedPeepId = quotedPeepId;
        Quote = quote;
    }

    public Guid QuotedPeepId { get; init; }
    public Domain.Aggregates.PeepAggregate.Peep Quote { get; init; }
}


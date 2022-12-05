using Peep.EventBus.Events;
namespace Peep.Parrot.Application.Events;

public class PeepQuoteRemoved : Event
{
    public PeepQuoteRemoved(Guid quotedPeepId, Domain.Entities.Peep quote)
    {
        QuotedPeepId = quotedPeepId;
        Quote = quote;
    }

    public Guid QuotedPeepId { get; init; }
    public Domain.Entities.Peep Quote { get; init; }
}


using Peep.EventBus.Events;
namespace Peep.Parrot.Application.Events;

public class PeepQuoted : Event
{
    public PeepQuoted(Guid quotedPeepId, Domain.Entities.Peep quote)
    {
        QuotedPeepId = quotedPeepId;
        Quote = quote;
    }

    public Guid QuotedPeepId { get; init; }
    public Domain.Entities.Peep Quote { get; init; }
}


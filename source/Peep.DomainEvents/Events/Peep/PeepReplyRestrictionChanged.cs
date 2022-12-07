using Peep.EventBus;
namespace Peep.DomainEvents.Events.Peep;

public class PeepReplyRestrictionChanged : Event
{
    public PeepReplyRestrictionChanged(Guid peepId, byte replyRestriction)
    {
        PeepId = peepId;
        ReplyRestriction = replyRestriction;
    }

    public Guid PeepId { get; init; }
    public byte ReplyRestriction { get; init; }
}

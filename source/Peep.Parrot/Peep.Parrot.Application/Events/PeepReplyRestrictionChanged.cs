using Peep.EventBus.Events;
using Peep.Parrot.Domain.Enums;
namespace Peep.Parrot.Application.Events;

public class PeepReplyRestrictionChanged : Event
{
    public PeepReplyRestrictionChanged(Guid peepId, EPeepReplyRestriction replyRestriction)
    {
        PeepId = peepId;
        ReplyRestriction = replyRestriction;
    }

    public Guid PeepId { get; init; }
    public EPeepReplyRestriction ReplyRestriction { get; init; }
}

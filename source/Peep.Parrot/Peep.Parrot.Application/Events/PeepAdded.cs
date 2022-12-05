using Peep.EventBus.Events;
using Peep.Parrot.Domain.Enums;
using Peep.Parrot.Domain.ValueObjects;
namespace Peep.Parrot.Application.Events;

public class PeepAdded : Event
{
    public PeepAdded(Guid peepId, Guid userId, DateOnly publicationDate, TimeOnly publicationTime, EPeepSource source, EPeepViewRestriction viewRestriction, EPeepReplyRestriction replyRestriction, Guid? quotedPeepId, Guid? repliedPeepId, PeepContent peepContent)
    {
        PeepId = peepId;
        UserId = userId;
        PublicationDate = publicationDate;
        PublicationTime = publicationTime;
        Source = source;
        ViewRestriction = viewRestriction;
        ReplyRestriction = replyRestriction;
        QuotedPeepId = quotedPeepId;
        RepliedPeepId = repliedPeepId;
        PeepContent = peepContent;
    }

    public Guid PeepId { get; init; }
    public Guid UserId { get; init; }
    public DateOnly PublicationDate { get; init; }
    public TimeOnly PublicationTime { get; init; }
    public EPeepSource Source { get; init; }
    public EPeepViewRestriction ViewRestriction { get; init; }
    public EPeepReplyRestriction ReplyRestriction { get; init; }
    public Guid? QuotedPeepId { get; init; }
    public Guid? RepliedPeepId { get; init; }
    public PeepContent PeepContent { get; init; }
}

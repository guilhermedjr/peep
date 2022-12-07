using Peep.EventBus;
namespace Peep.DomainEvents.Events.Peep;

public class PeepAdded : Event
{
    public PeepAdded(Guid peepId, Guid userId, DateOnly publicationDate, TimeOnly publicationTime, byte source, byte viewRestriction, byte replyRestriction, Guid? quotedPeepId, Guid? repliedPeepId, object peepContent)
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
    public byte Source { get; init; }
    public byte ViewRestriction { get; init; }
    public byte ReplyRestriction { get; init; }
    public Guid? QuotedPeepId { get; init; }
    public Guid? RepliedPeepId { get; init; }
    public object PeepContent { get; init; }
}

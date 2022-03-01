using Peep.Timeline.Enums;
namespace Peep.Timeline.Entities;

public class Peep
{
    private IList<Peep> _quotes;
    private readonly IList<User> _rps;
    private readonly IList<User> _likes;
    private readonly IList<Peep> _replies;

    public Guid Id { get; private set; }
    public User User { get; private set; }
    public Guid UserId { get; private set; }
    public DateOnly PublicationDate { get; set; }
    public TimeOnly PublicationTime { get; set; }
    public string TextContent { get; private set; }
    public EPeepSource Source { get; private set; }
    public EPeepReplyRestriction ReplyRestriction { get; private set; }
    public Guid? QuotedPeepId { get; private set; }
    public Guid? RepliedPeepId { get; private set; }
    public IReadOnlyCollection<Peep> Quotes { get { return _quotes.ToArray(); } }
    public IReadOnlyCollection<User> Rps { get { return _rps.ToArray(); } }
    public IReadOnlyCollection<User> Likes { get { return _likes.ToArray(); } }
    public IReadOnlyCollection<Peep> Replies { get { return _replies.ToArray(); } }
}

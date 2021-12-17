using System.ComponentModel.DataAnnotations.Schema;

namespace Peep.Parrot.Domain.Entities;

public class Peep
{
    private readonly IList<Peep> _quotes;
    private readonly IList<ApplicationUser> _rps;
    private readonly IList<ApplicationUser> _likes;
    private readonly IList<Peep> _replies;

    /// <summary>
    /// ORM constructor
    /// </summary>
    protected Peep() { }

    public Peep(Guid userId, string textContent,
        EPeepSource source, EPeepReplyRestriction replyRestriction)
    {
        UserId = userId;
        TextContent = textContent;
        Source = source;
        ReplyRestriction = replyRestriction;
        PublicationDate = null;
        PublicationTime = null;
        _quotes = new List<Peep>();
        _rps = new List<ApplicationUser>();
        _likes = new List<ApplicationUser>();
        _replies = new List<Peep>();
    }

    public Guid Id { get; private set; }
    public ApplicationUser User { get; private set; }
    public Guid UserId { get; private set; }
    [NotMapped]
    public DateOnly? PublicationDate { get; private set; }
    [NotMapped]
    public TimeOnly? PublicationTime { get; private set; }
    public string TextContent { get; private set; }
    public EPeepSource Source { get; private set; }
    public EPeepReplyRestriction ReplyRestriction { get; private set; }
    public Guid? QuotedPeepId { get; private set; }
    public Guid? RepliedPeepId { get; private set; }
    public IReadOnlyCollection<Peep> Quotes { get { return _quotes.ToArray(); } }
    public IReadOnlyCollection<ApplicationUser> Rps { get { return _rps.ToArray(); } }
    public IReadOnlyCollection<ApplicationUser> Likes { get { return _likes.ToArray(); } }
    public IReadOnlyCollection<Peep> Replies { get { return _replies.ToArray(); } }

    public void ChangeReplyRestriction(EPeepReplyRestriction replyRestriction) =>
        ReplyRestriction = replyRestriction;

    public void AddQuote(Peep quote) =>
        _quotes.Add(quote);

    public void DeleteQuote(Peep quote) =>
        _quotes.Remove(quote);

    public void AddRepeep(ApplicationUser ApplicationUser) =>
        _rps.Add(ApplicationUser);

    public void RemoveRepeep(ApplicationUser ApplicationUser) =>
        _rps.Remove(ApplicationUser);

    public void AddLike(ApplicationUser ApplicationUser) =>
        _likes.Add(ApplicationUser);

    public void RemoveLike(ApplicationUser ApplicationUser) =>
        _likes.Remove(ApplicationUser);

    public void AddReply(Peep reply) =>
        _replies.Add(reply);

    public void DeleteReply(Peep reply) =>
        _replies.Remove(reply);

}


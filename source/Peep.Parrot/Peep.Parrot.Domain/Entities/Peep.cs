namespace Peep.Parrot.Domain.Entities;

public class Peep : Entity
{
    private readonly IList<Quote> _quotes;
    private readonly IList<ApplicationUser> _rps;
    private readonly IList<ApplicationUser> _likes;
    private readonly IList<Reply> _replies;

    /// <summary>
    /// ORM constructor
    /// </summary>
    protected Peep() { }

    public Peep(ApplicationUser applicationUser, string textContent, 
        EPeepSource source, EPeepReplyRestriction replyRestriction)
    {
        ApplicationUser = applicationUser;
        TextContent = textContent;
        //PublicationDate = DateTime;
        Source = source;
        ReplyRestriction = replyRestriction;
        _quotes = new List<Quote>();
        _rps = new List<ApplicationUser>();
        _likes = new List<ApplicationUser>();
        _replies = new List<Reply>();
    }

    public readonly ApplicationUser ApplicationUser;
    public readonly Guid ApplicationUserId;
    public readonly DateOnly PublicationDate;
    public readonly TimeOnly PublicationTime;
    public string TextContent { get; private set; }
    public readonly EPeepSource Source;
    public EPeepReplyRestriction ReplyRestriction { get; private set; }
    public IReadOnlyCollection<Quote> Quotes { get { return _quotes.ToArray(); } }
    public IReadOnlyCollection<ApplicationUser> Rps { get { return _rps.ToArray(); } }
    public IReadOnlyCollection<ApplicationUser> Likes { get { return _likes.ToArray(); } }
    public IReadOnlyCollection<Reply> Replies { get { return _replies.ToArray(); } }

    public void ChangeReplyRestriction(EPeepReplyRestriction replyRestriction) =>
        ReplyRestriction = replyRestriction;

    public void AddQuote(Quote quote) =>
        _quotes.Add(quote);

    public void DeleteQuote(Quote quote) =>
        _quotes.Remove(quote);

    public void AddRepeep(ApplicationUser ApplicationUser) =>
        _rps.Add(ApplicationUser);

    public void RemoveRepeep(ApplicationUser ApplicationUser) =>
        _rps.Remove(ApplicationUser);

    public void AddLike(ApplicationUser ApplicationUser) =>
        _likes.Add(ApplicationUser);

    public void RemoveLike(ApplicationUser ApplicationUser) =>
        _likes.Remove(ApplicationUser);

    public void AddReply(Reply reply) =>
        _replies.Add(reply);

    public void DeleteReply(Reply reply) =>
        _replies.Remove(reply);

}


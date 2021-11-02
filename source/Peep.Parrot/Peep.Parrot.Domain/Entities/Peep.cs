namespace Peep.Parrot.Domain.Entities;

public class Peep : Entity
{
    private readonly IList<Quote> _quotes;
    private readonly IList<User> _rps;
    private readonly IList<User> _likes;
    private readonly IList<Reply> _replies;

    public Peep(User user, DateTime publicationDateTime, string description, 
        EPeepSource source, EPeepReplyRestriction replyRestriction)
    {
        User = user;
        PublicationDateTime = publicationDateTime;
        Description = description;
        Source = source;
        ReplyRestriction = replyRestriction;
        _quotes = new List<Quote>();
        _rps = new List<User>();
        _likes = new List<User>();
        _replies = new List<Reply>();
    }

    public User User { get; private set; }
    public DateTime PublicationDateTime { get; private set; }
    public string Description { get; private set; }
    public EPeepSource Source { get; private set; }
    public EPeepReplyRestriction ReplyRestriction { get; private set; }
    public IReadOnlyCollection<Quote> Quotes { get { return _quotes.ToArray(); } }
    public IReadOnlyCollection<User> Rps { get { return _rps.ToArray(); } }
    public IReadOnlyCollection<User> Likes { get { return _likes.ToArray(); } }
    public IReadOnlyCollection<Reply> Replies { get { return _replies.ToArray(); } }

    public void ChangeReplyRestriction(EPeepReplyRestriction replyRestriction) =>
        ReplyRestriction = replyRestriction;

    public void AddQuote(Quote quote) =>
        _quotes.Add(quote);

    public void DeleteQuote(Quote quote) =>
        _quotes.Remove(quote);

    public void AddRepeep(User user) =>
        _rps.Add(user);

    public void RemoveRepeep(User user) =>
        _rps.Remove(user);

    public void AddLike(User user) =>
        _likes.Add(user);

    public void RemoveLike(User user) =>
        _likes.Remove(user);

    public void AddReply(Reply reply) =>
        _replies.Add(reply);

    public void DeleteReply(Reply reply) =>
        _replies.Remove(reply);

}


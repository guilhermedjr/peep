using Peep.Parrot.Domain.ValueObjects;
namespace Peep.Parrot.Domain.Entities;

public class Peep
{
    private readonly Dictionary<ApplicationUser, DateTime> _likes;
    private readonly Dictionary<ApplicationUser, DateTime> _rps;
    private readonly IList<Peep> _replies;
    private readonly IList<Peep> _quotes;

    private readonly IList<PeepVersionSnapshot> _versionHistory;

    /// <summary>
    /// ORM ctor
    /// </summary>
    protected Peep() { }

    /// <summary>
    /// Scheduled peep ctor
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="peepContent"></param>
    /// <param name="date"></param>
    /// <param name="time"></param>
    /// <param name="source"></param>
    /// <param name="viewRestriction"></param>
    /// <param name="replyRestriction"></param>
    /// <param name="quotedPeep"></param>
    /// <param name="repliedPeep"></param>
    public Peep(Guid userId, PeepContent peepContent,
        DateOnly date, TimeOnly time,
        EPeepSource source, EPeepViewRestriction viewRestriction, EPeepReplyRestriction replyRestriction,
        Peep quotedPeep = null, Peep repliedPeep = null)
    {
        Id = new Guid();
        UserId = userId;
        PeepContent = peepContent;
        Source = source;
        ViewRestriction = viewRestriction;
        ReplyRestriction = replyRestriction;
        QuotedPeep = quotedPeep;
        RepliedPeep = repliedPeep;
        PublicationDate = date;
        PublicationTime = time;

        _replies = new List<Peep>();
        _quotes = new List<Peep>();
    }

    /// <summary>
    /// Normal peep ctor
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="peepContent"></param>
    /// <param name="source"></param>
    /// <param name="viewRestriction"></param>
    /// <param name="replyRestriction"></param>
    /// <param name="quotedPeep"></param>
    /// <param name="repliedPeep"></param>
    public Peep(Guid userId, PeepContent peepContent, 
        EPeepSource source, EPeepViewRestriction viewRestriction, EPeepReplyRestriction replyRestriction,
        Peep quotedPeep = null, Peep repliedPeep = null)
    {
        Id = new Guid();
        UserId = userId;
        PeepContent = peepContent;
        Source = source;
        ViewRestriction = viewRestriction;
        ReplyRestriction = replyRestriction;
        QuotedPeep = quotedPeep;
        RepliedPeep = repliedPeep;

        var now = DateTime.UtcNow;
        PublicationDate = DateOnly.FromDateTime(now);
        PublicationTime = TimeOnly.FromDateTime(now);

        _replies = new List<Peep>();
        _quotes = new List<Peep>();
    }

    public Guid Id { get; private set; }
    public ApplicationUser User { get; private set; }
    public Guid UserId { get; private set; }
    public DateOnly PublicationDate { get; set; }
    public TimeOnly PublicationTime { get; set; }
    public EPeepSource Source { get; private set; } = EPeepSource.Undefined;
    public EPeepViewRestriction ViewRestriction { get; private set; } = EPeepViewRestriction.Everyone;
    public EPeepReplyRestriction ReplyRestriction { get; private set; } = EPeepReplyRestriction.Everyone;
    public Peep QuotedPeep { get; private set; } = null;
    public Peep RepliedPeep { get; private set; } = null;

    public PeepContent PeepContent { get; private set; }

    public Dictionary<ApplicationUser, DateTime> Likes { get { return _likes; } }
    public IReadOnlyCollection<Peep> Replies { get { return _replies.ToArray(); } }
    public IReadOnlyCollection<Peep> Quotes { get { return _quotes.ToArray(); } }
    public Dictionary<ApplicationUser, DateTime> Rps { get { return _rps; } }

    public IReadOnlyCollection<PeepVersionSnapshot> VersionHistory { get { return _versionHistory.ToArray(); } }

    public void EditPeep(PeepContent editedContent)
    {
        var peepSnapshot = new PeepVersionSnapshot(Id, PeepContent, PublicationDate, PublicationTime, Likes, Replies, Quotes, Rps);
        _versionHistory.Add(peepSnapshot);

        PeepContent = editedContent;
    }

    public void ChangeReplyRestriction(EPeepReplyRestriction replyRestriction)
    {
        ReplyRestriction = replyRestriction;
    }

    public void Like(ApplicationUser user)
    {
        _likes.Add(user, DateTime.UtcNow);
    }

    public void RemoveLike(ApplicationUser user)
    {
        _likes.Remove(user);
    }

    public void Repeep(ApplicationUser user)
    {
        _rps.Add(user, DateTime.UtcNow);
    }

    public void RemoveRp(ApplicationUser user)
    { 
        _rps.Remove(user); 
    }

    public void Reply(Guid userId, PeepContent peepContent, EPeepSource source)
    {
        var reply = new Peep(userId, peepContent, source, EPeepViewRestriction.Everyone, EPeepReplyRestriction.Everyone, repliedPeep: this);
        _replies.Add(reply);
    }

    public void Quote(Guid userId, PeepContent peepContent, EPeepSource source, EPeepViewRestriction viewRestriction)
    {
        var quote = new Peep(userId, peepContent, source, viewRestriction, 
            viewRestriction == EPeepViewRestriction.Cicle ? EPeepReplyRestriction.Cicle : EPeepReplyRestriction.Everyone, quotedPeep: this);

        _quotes.Add(quote);
    }

    public int GetLikesCount() => _likes.Count;
    public int GetQuotesCount() => _quotes.Count;
    public int GetRepeepsCount() => _rps.Count;

}


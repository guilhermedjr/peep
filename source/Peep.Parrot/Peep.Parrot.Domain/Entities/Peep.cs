using Peep.Parrot.Domain.ValueObjects;
namespace Peep.Parrot.Domain.Entities;

public class Peep
{
    private readonly Dictionary<Guid, DateTime> _likes;
    private readonly Dictionary<Guid, DateTime> _rps;
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
    /// <param name="quotedPeepId"></param>
    /// <param name="repliedPeepId"></param>
    public Peep(Guid userId, PeepContent peepContent,
        DateOnly date, TimeOnly time,
        EPeepSource source, EPeepViewRestriction viewRestriction, EPeepReplyRestriction replyRestriction,
        Guid? quotedPeepId = null, Guid? repliedPeepId = null)
    {
        Id = new Guid();
        UserId = userId;
        PeepContent = peepContent;
        Source = source;
        ViewRestriction = viewRestriction;
        ReplyRestriction = replyRestriction;
        QuotedPeepId = quotedPeepId;
        RepliedPeepId = repliedPeepId;
        PublicationDate = date;
        PublicationTime = time;

        _likes = new Dictionary<Guid, DateTime>();
        _rps = new Dictionary<Guid, DateTime>();

        _replies = new List<Peep>();
        _quotes = new List<Peep>();
        _versionHistory = new List<PeepVersionSnapshot>();
    }

    /// <summary>
    /// Normal peep ctor
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="peepContent"></param>
    /// <param name="source"></param>
    /// <param name="viewRestriction"></param>
    /// <param name="replyRestriction"></param>
    /// <param name="quotedPeepId"></param>
    /// <param name="repliedPeepId"></param>
    public Peep(Guid userId, PeepContent peepContent, 
        EPeepSource source, EPeepViewRestriction viewRestriction, EPeepReplyRestriction replyRestriction,
        Guid? quotedPeepId = null, Guid? repliedPeepId = null)
    {
        Id = new Guid();
        UserId = userId;
        PeepContent = peepContent;
        Source = source;
        ViewRestriction = viewRestriction;
        ReplyRestriction = replyRestriction;
        QuotedPeepId = quotedPeepId;
        RepliedPeepId = repliedPeepId;

        var now = DateTime.UtcNow;
        PublicationDate = DateOnly.FromDateTime(now);
        PublicationTime = TimeOnly.FromDateTime(now);

        _likes = new Dictionary<Guid, DateTime>();
        _rps = new Dictionary<Guid, DateTime>();

        _replies = new List<Peep>();
        _quotes = new List<Peep>();
        _versionHistory = new List<PeepVersionSnapshot>();
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public DateOnly PublicationDate { get; set; }
    public TimeOnly PublicationTime { get; set; }
    public EPeepSource Source { get; private set; } = EPeepSource.Undefined;
    public EPeepViewRestriction ViewRestriction { get; private set; } = EPeepViewRestriction.Everyone;
    public EPeepReplyRestriction ReplyRestriction { get; private set; } = EPeepReplyRestriction.Everyone;

    public Peep QuotedPeep { get; private set; } = null;
    public Peep RepliedPeep { get; private set; } = null;
    public Guid? QuotedPeepId { get; private set; } = null;
    public Guid? RepliedPeepId { get; private set; } = null;

    public PeepContent PeepContent { get; private set; }

    public Dictionary<Guid, DateTime> Likes { get { return _likes; } }
    public IReadOnlyCollection<Peep> Replies { get { return _replies.ToArray(); } }
    public IReadOnlyCollection<Peep> Quotes { get { return _quotes.ToArray(); } }
    public Dictionary<Guid, DateTime> Rps { get { return _rps; } }

    public IReadOnlyCollection<PeepVersionSnapshot> VersionHistory { get { return _versionHistory.ToArray(); } }

    public void EditPeep(PeepContent editedContent)
    {
        var peepSnapshot = new PeepVersionSnapshot(Id, PeepContent, PublicationDate, PublicationTime, Likes, Replies, Quotes, Rps);
        _versionHistory.Add(peepSnapshot);

        PeepContent = editedContent;

        var now = DateTime.UtcNow;
        PublicationDate = DateOnly.FromDateTime(now);
        PublicationTime = TimeOnly.FromDateTime(now);
    }

    public void ChangeReplyRestriction(EPeepReplyRestriction replyRestriction)
    {
        ReplyRestriction = replyRestriction;
    }

    public void Like(Guid user)
    {
        _likes.Add(user, DateTime.UtcNow);
    }

    public void RemoveLike(Guid user)
    {
        _likes.Remove(user);
    }

    public void Repeep(Guid user)
    {
        _rps.Add(user, DateTime.UtcNow);
    }

    public void RemoveRp(Guid user)
    { 
        _rps.Remove(user); 
    }

    public void AddReply(Peep peep)
    {
        _replies.Add(peep);
    }

    public void RemoveReply(Peep peep)
    {
        _replies.Remove(peep);
    }

    public void AddQuote(Peep peep)
    {
        _quotes.Add(peep);
    }

    public void RemoveQuote(Peep peep)
    {
        _quotes.Remove(peep);
    }

    public int GetLikesCount() => _likes.Count;
    public int GetQuotesCount() => _quotes.Count;
    public int GetRepeepsCount() => _rps.Count;

}


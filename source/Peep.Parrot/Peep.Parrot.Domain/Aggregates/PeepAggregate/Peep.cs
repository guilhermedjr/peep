using Peep.Parrot.Domain.Enums;
using Peep.Parrot.Domain.SeedWork;
namespace Peep.Parrot.Domain.Aggregates.PeepAggregate;

public class Peep : Entity, IAggregateRoot
{
    private readonly IList<PeepLike> _likes;
    private readonly IList<PeepRepost> _rps;
    private readonly IList<Peep> _replies;
    private readonly IList<Peep> _quotes;

    private readonly IList<PeepDislike> _dislikes;
    private readonly IList<PeepDisrepost> _disreposts;

    private readonly IList<PeepVersionSnapshot> _versionHistory;

    /// <summary>
    /// ORM ctor
    /// </summary>
    protected Peep() { }

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

        _likes = new List<PeepLike>();
        _rps = new List<PeepRepost>();

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

    public IReadOnlyCollection<PeepLike> Likes { get { return _likes.ToArray(); } }
    public IReadOnlyCollection<Peep> Replies { get { return _replies.ToArray(); } }
    public IReadOnlyCollection<Peep> Quotes { get { return _quotes.ToArray(); } }
    public IReadOnlyCollection<PeepRepost> Rps { get { return _rps.ToArray(); } }

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
        _likes.Add(new PeepLike(Id, user));
    }

    public void RemoveLike(Guid user)
    {
        _dislikes.Add(new PeepDislike(Id, user));
    }

    public void Repeep(Guid user)
    {
        _rps.Add(new PeepRepost(Id, user));
    }

    public void RemoveRp(Guid user)
    {
        _disreposts.Add(new PeepDisrepost(Id, user));
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

    // 🤯 event sourcing? 
    private int GetLikesCount()
    {
        // listar todos os PeepLike e todos os PeepDislike
        // pra cada "user" que realizou no mínimo um like, verificar os eventos e checar qual foi a última ação realizada (like ou dislike)
        // se foi um like, adiciona mais um like na contagem
        return 0;
    }

    private int GetRepliesCount() => _replies.Count;
    private int GetQuotesCount() => _quotes.Count;
    private int GetRepeepsCount() => _rps.Count;
}

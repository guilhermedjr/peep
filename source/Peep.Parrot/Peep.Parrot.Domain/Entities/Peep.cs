using System.ComponentModel.DataAnnotations.Schema;

namespace Peep.Parrot.Domain.Entities;

public class Peep
{
    /*private readonly IList<Peep> _quotes;
    private readonly IList<ApplicationUser> _rps;
    private readonly IList<ApplicationUser> _likes;
    private readonly IList<Peep> _replies;*/

    /// <summary>
    /// ORM constructor
    /// </summary>
    protected Peep() { }

    public Peep(Guid id, Guid userId, string textContent,
        DateOnly date, TimeOnly time,
        EPeepSource source, EPeepReplyRestriction replyRestriction)
    {
        Id = id;
        UserId = userId;
        TextContent = textContent;
        Source = source;
        ReplyRestriction = replyRestriction;
        PublicationDate = date;
        PublicationTime = time;
        /*_quotes = new List<Peep>();
        _rps = new List<ApplicationUser>();
        _likes = new List<ApplicationUser>();
        _replies = new List<Peep>();*/
    }

    /*public Peep(Guid userId, string textContent, EPeepSource source, EPeepReplyRestriction replyRestriction)
    {
        UserId = userId;
        TextContent = textContent;
        Source = source;
        ReplyRestriction = replyRestriction;
    }*/

    public Guid Id { get; private set; }
    public ApplicationUser User { get; private set; }
    public Guid UserId { get; private set; }
    public DateOnly PublicationDate { get; set; }
    public TimeOnly PublicationTime { get; set; }
    public string TextContent { get; private set; }
    public EPeepSource Source { get; private set; }
    public EPeepReplyRestriction ReplyRestriction { get; private set; }
    public Guid? QuotedPeepId { get; private set; }
    public Guid? RepliedPeepId { get; private set; }
    /*public IReadOnlyCollection<Peep> Quotes { get { return _quotes.ToArray(); } }
    public IReadOnlyCollection<ApplicationUser> Rps { get { return _rps.ToArray(); } }
    public IReadOnlyCollection<ApplicationUser> Likes { get { return _likes.ToArray(); } }
    public IReadOnlyCollection<Peep> Replies { get { return _replies.ToArray(); } }*/

}


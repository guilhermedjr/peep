namespace Peep.Parrot.Domain.Entities;

public class Quote : Peep
{
    /// <summary>
    /// ORM constructor
    /// </summary>
    private Quote() { }

    public Quote(User user, string description, EPeepSource source, 
        EPeepReplyRestriction replyRestriction, Peep quotedPeep) 
    : base(user, description, source, replyRestriction)

    {
        QuotedPeep = quotedPeep;
    }

    public readonly Peep QuotedPeep;
}


namespace Peep.Parrot.Domain.Entities;

public class Quote : Peep
{
    public Quote(User user, DateTime publicationDateTime, string description, EPeepSource source, 
        EPeepReplyRestriction replyRestriction, Peep quotedPeep) 
    : base(user, publicationDateTime, description, source, replyRestriction)

    {
        QuotedPeep = quotedPeep;
    }

    public Peep QuotedPeep { get; private set; }
}


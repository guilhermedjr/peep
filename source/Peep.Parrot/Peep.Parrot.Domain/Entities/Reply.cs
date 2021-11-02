namespace Peep.Parrot.Domain.Entities;

public class Reply : Peep
{
    public Reply(User user, DateTime publicationDateTime, string description, EPeepSource source,
       EPeepReplyRestriction replyRestriction, Peep repliedPeep)
   : base(user, publicationDateTime, description, source, replyRestriction)

    {
        RepliedPeep = repliedPeep;
    }

    public Peep RepliedPeep { get; private set; }
}


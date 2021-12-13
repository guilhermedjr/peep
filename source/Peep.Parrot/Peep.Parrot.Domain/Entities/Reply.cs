namespace Peep.Parrot.Domain.Entities;

public class Reply : Peep
{
    /// <summary>
    /// ORM constructor
    /// </summary>
    private Reply() { }

    public Reply(ApplicationUser user, string description, EPeepSource source,
       EPeepReplyRestriction replyRestriction, Peep repliedPeep)
    : base(user, description, source, replyRestriction)

    {
        RepliedPeep = repliedPeep;
    }

    public readonly Peep RepliedPeep;
}


namespace Peep.Parrot.GraphQL.Types;

public class PeepType : ObjectGraphType<Domain.Entities.Peep>
{
    public PeepType()
    {
        Name = "peep";

        Field(p => p.Id);
        Field(p => p.UserId);
        Field(p => p.User);
        Field(p => p.PublicationDate);
        Field(p => p.PublicationTime);
        Field(p => p.TextContent);
        Field(p => p.Source);
        Field(p => p.ReplyRestriction);
        Field(p => p.QuotedPeepId, nullable: true);
        Field(p => p.QuotedPeep, nullable: true);
        Field(p => p.RepliedPeepId, nullable: true);
        Field(p => p.Quotes);
        Field(p => p.Replies);
        Field(p => p.Rps);
        Field(p => p.Likes);
    }
}

public class PeepInputType : InputObjectGraphType<Domain.Entities.Peep>
{
    public PeepInputType()
    {
        Name = "peep";

        Field(p => p.Id);
        Field(p => p.UserId);
        Field(p => p.User);
        Field(p => p.TextContent);
        Field(p => p.Source);
        Field(p => p.ReplyRestriction);
        Field(p => p.QuotedPeepId);
        Field(p => p.RepliedPeepId);
    }
}


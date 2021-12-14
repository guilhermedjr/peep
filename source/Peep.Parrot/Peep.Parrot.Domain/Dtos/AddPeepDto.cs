namespace Peep.Parrot.Domain.Dtos;

public class AddPeepDto
{
    public Guid UserId { get; set; }
    [MaxLength(280)]
    public string TextContent { get; set; }
    /*public EPeepSource Source { get; set; }
    public EPeepReplyRestriction ReplyRestriction { get; set; }
    public Guid QuotedPeepId { get; set; }
    public Guid RepliedPeepId { get; set; }*/
}


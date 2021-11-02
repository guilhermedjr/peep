namespace Peep.Parrot.Domain.Dtos;

public class EditPeepDto
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid PeepId { get; set; }
        
    public string Description { get; set; }
    public EPeepReplyRestriction ReplyRestriction { get; set; }
}


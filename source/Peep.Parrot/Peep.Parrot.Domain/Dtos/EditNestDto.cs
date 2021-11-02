namespace Peep.Parrot.Domain.Dtos;

public class EditNestDto
{
    [Required]
    public Guid OwnerId { get; set; }
    [Required]
    public Guid NestId { get; set; }
        
    public bool IsPublic { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}


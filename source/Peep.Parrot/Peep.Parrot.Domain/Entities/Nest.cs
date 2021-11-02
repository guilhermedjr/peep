namespace Peep.Parrot.Domain.Entities;

public class Nest
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public bool IsPublic { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<User> Members { get; set; }
    public List<User> Followers { get; set; }
    public DateTime CreatedAt { get; set; }

}


namespace Peep.Wings.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string Username { get; set; }
    public DateTime BirthDate { get; set; }
    public string ProfileImageUrl { get; set; }
    public DateTime JoinedAt { get; set; }
}


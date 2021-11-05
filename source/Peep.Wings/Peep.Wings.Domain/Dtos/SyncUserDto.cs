namespace Peep.Wings.Domain.Dtos;

public class SyncUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public DateTime BirthDate { get; set; }
    public string ProfileImageUrl { get; set; }
    public DateTime JoinedAt { get; set; }
}


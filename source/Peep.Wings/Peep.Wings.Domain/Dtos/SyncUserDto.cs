namespace Peep.Wings.Domain.Dtos;

public class SyncUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string BirthDate { get; set; }
    public DateTime JoinedAt { get; set; }
}


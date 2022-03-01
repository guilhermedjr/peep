namespace Peep.Timeline.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Name { get; private set; }
    public string Username { get; private set; }
    public string ProfileImageUrl { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public DateTime JoinedAt { get; private set; }

    public string Bio { get; private set; }
    public string Location { get; private set; }
    public string Website { get; private set; }

    public bool PrivateAccount { get; private set; }
    public bool VerifiedAccount { get; private set; }

    public IEnumerable<Peep> Peeps { get; set; }
}

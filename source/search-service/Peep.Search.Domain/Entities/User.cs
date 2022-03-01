namespace Peep.Search.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Username { get; private set; }
    public string ProfileImageUrl { get; private set; }
    public string Bio { get; private set; }
    public string Location { get; private set; }
    public bool PrivateAccount { get; private set; }
    public bool VerifiedAccount { get; private set; }
}

namespace Peep.Timeline.Entities;

public class User
{
    private readonly IList<User> _following;
    private readonly IList<User> _blockedUsers;
    private readonly IList<User> _mutedUsers;

    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Name { get; private set; }
    public string Username { get; private set; }
    public IEnumerable<Peep> Peeps { get; set; }
    public IEnumerable<User> Following { get; set; }
    public IEnumerable<User> BlockedUsers { get; set; }
    public IEnumerable<User> MutedUsers { get; set; }

}

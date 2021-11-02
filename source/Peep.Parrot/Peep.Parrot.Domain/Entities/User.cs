namespace Peep.Parrot.Domain.Entities;

public class User : Entity
{
    private readonly IList<User> _following;
    private readonly IList<User> _followers;
    private readonly IList<Peep> _peeps;
    private readonly IList<Nest> _userNests;
    private readonly IList<Nest> _nests;
    private readonly IList<User> _followRequests;
    private readonly IList<User> _blockedUsers;
    private readonly IList<User> _mutedUsers;

    public User(bool isPrivateAccount, string name, string username, string bio, string location, string website)
    {
        IsPrivateAccount = isPrivateAccount;
        Name = name;
        Username = username;
        Bio = bio;
        Location = location;
        Website = website;
        _following = new List<User>();
        _followers = new List<User>();
        _peeps = new List<Peep>();
        _userNests = new List<Nest>();
        _nests = new List<Nest>();
        _followRequests = new List<User>();
        _blockedUsers = new List<User>();
        _mutedUsers = new List<User>();
    }

    public bool IsPrivateAccount { get; private set; } 
    public string Name { get; private set; }
    public string Username { get; private set; }
    public string Bio { get; private set; }
    public string Location { get; private set; }
    public string Website { get; private set; }
    public IReadOnlyCollection<User> Following { get { return _following.ToList(); } }
    public ICollection<User> Followers { get { return _followers.ToArray(); } }
    public IReadOnlyCollection<Peep> Peeps { get { return _peeps.ToArray(); } }
    public IReadOnlyCollection<Nest> UserNests { get { return _userNests.ToArray(); } }
    public IReadOnlyCollection<Nest> Nests { get { return _nests.ToArray(); } }
    public IReadOnlyCollection<User> FollowRequests { get { return _followRequests.ToArray(); } }
    public IReadOnlyCollection<User> BlockedUsers { get { return _blockedUsers.ToArray(); } }
    public IReadOnlyCollection<User> MutedUsers { get { return _mutedUsers.ToArray(); } }

    public void ChangeAccountPrivacy() =>
        IsPrivateAccount = !IsPrivateAccount;

    public void AddPeep(Peep peep) =>
        _peeps.Add(peep);

    public void DeletePeep(Peep peep) =>
        _peeps.Remove(peep);

    public void BlockUser(User user) => 
        _blockedUsers.Add(user);

    public void UnblockUser(User user) =>
        _blockedUsers.Remove(user);

    public void MuteUser(User user) =>
        _mutedUsers.Add(user);

    public void UnmuteUser(User user) =>
        _mutedUsers.Remove(user);

    public void AddNest(Nest nest) =>
        _userNests.Add(nest);

    public void DeleteNest(Nest nest) =>
        _userNests.Remove(nest);
}


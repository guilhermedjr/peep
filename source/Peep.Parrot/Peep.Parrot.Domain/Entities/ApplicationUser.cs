using System.ComponentModel.DataAnnotations.Schema;

namespace Peep.Parrot.Domain.Entities;

/* Attributes that can be used in both NoSQL and SQL databases, and entity methods */
public partial class ApplicationUser
{
    private readonly IList<Peep> _peeps;

    private readonly IList<ApplicationUser> _following;
    private readonly IList<ApplicationUser> _followers;
    private readonly IList<Nest> _userNests;
    private readonly IList<Nest> _nests;
    private readonly IList<ApplicationUser> _followRequests;
    private readonly IList<ApplicationUser> _blockedUsers;
    private readonly IList<ApplicationUser> _mutedUsers;

    public ApplicationUser(bool isPrivateAccount, string name, string username, string bio, string location, string website)
    {
        IsPrivateAccount = isPrivateAccount;
        Name = name;
        Username = username;
        Bio = bio;
        Location = location;
        Website = website;
        _following = new List<ApplicationUser>();
        _followers = new List<ApplicationUser>();
        _peeps = new List<Peep>();
        _userNests = new List<Nest>();
        _nests = new List<Nest>();
        _followRequests = new List<ApplicationUser>();
        _blockedUsers = new List<ApplicationUser>();
        _mutedUsers = new List<ApplicationUser>();

        _followships = new List<Followship>();
        _mutes = new List<Mute>();
        _blocks = new List<Block>();
    }

    public Guid Id { get; private set; }
    public bool IsPrivateAccount { get; private set; } 
    public string Name { get; private set; }
    public string Username { get; private set; }
    public string Bio { get; private set; }
    public string Location { get; private set; }
    public string Website { get; private set; }
    
    public IReadOnlyCollection<Peep> Peeps { get { return _peeps.ToArray(); } }

    public void ChangeAccountPrivacy() =>
        IsPrivateAccount = !IsPrivateAccount;

    public void AddPeep(Peep peep) =>
        _peeps.Add(peep);

    public void DeletePeep(Peep peep) =>
        _peeps.Remove(peep);

    public void BlockUser(ApplicationUser user) => 
        _blockedUsers.Add(user);

    public void UnblockUser(ApplicationUser user) =>
        _blockedUsers.Remove(user);

    public void MuteUser(ApplicationUser user) =>
        _mutedUsers.Add(user);

    public void UnmuteUser(ApplicationUser user) =>
        _mutedUsers.Remove(user);

    public void AddNest(Nest nest) =>
        _userNests.Add(nest);

    public void DeleteNest(Nest nest) =>
        _userNests.Remove(nest);
}

/* Attributes that do not map to SQL databases */
/* Surrogate attrs for mapping are in the partial class declaration present in "DbModels" */
public partial class ApplicationUser
{
    [NotMapped]
    public IReadOnlyCollection<ApplicationUser> Following { get { return _following.ToList(); } }
    [NotMapped]
    public ICollection<ApplicationUser> Followers { get { return _followers.ToArray(); } }
    [NotMapped]
    public IReadOnlyCollection<Nest> UserNests { get { return _userNests.ToArray(); } }
    [NotMapped]
    public IReadOnlyCollection<Nest> Nests { get { return _nests.ToArray(); } }
    [NotMapped]
    public IReadOnlyCollection<ApplicationUser> FollowRequests { get { return _followRequests.ToArray(); } }
    [NotMapped]
    public IReadOnlyCollection<ApplicationUser> BlockedUsers { get { return _blockedUsers.ToArray(); } }
    [NotMapped]
    public IReadOnlyCollection<ApplicationUser> MutedUsers { get { return _mutedUsers.ToArray(); } }
}


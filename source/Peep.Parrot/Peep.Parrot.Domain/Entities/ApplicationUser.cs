using System.ComponentModel.DataAnnotations.Schema;

namespace Peep.Parrot.Domain.Entities;

/* Attributes that can be used in both NoSQL and SQL databases, and entity methods */
public partial class ApplicationUser
{
    private readonly IList<ApplicationUser> _following;
    private readonly IList<ApplicationUser> _followers;
    private readonly IList<Nest> _userNests;
    private readonly IList<Nest> _nests;
    private readonly IList<ApplicationUser> _followRequests;
    private readonly IList<ApplicationUser> _blockedUsers;
    private readonly IList<ApplicationUser> _mutedUsers;

    public ApplicationUser(Guid id, string email, string name, string username, 
        string profileImageUrl, DateOnly birthDate, DateTime joinedAt,
        bool isPrivateAccount, bool isVerifiedAccount, 
        string bio, string location, string website)
    {
        Id = id;
        Email = email;
        Name = name;
        Username = username;
        ProfileImageUrl = profileImageUrl;
        BirthDate = birthDate;
        JoinedAt = joinedAt;

        Bio = bio;
        Location = location;
        Website = website;

        PrivateAccount = isPrivateAccount;
        VerifiedAccount = isVerifiedAccount;
      
        _following = new List<ApplicationUser>();
        _followers = new List<ApplicationUser>();
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


namespace Peep.Parrot.Domain.Entities;

public class Nest
{
    private readonly IList<ApplicationUser> _members;
    private readonly IList<ApplicationUser> _followers;

    public Nest(ApplicationUser owner, bool isPublic, string name, string description)
    {
        Owner = owner;
        IsPublic = isPublic;
        Name = name;
        Description = description;
        _members = new List<ApplicationUser>();
        _followers = new List<ApplicationUser>();
        CreatedAt = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public readonly ApplicationUser Owner;
    public bool IsPublic { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyCollection<ApplicationUser> Members { get { return _members.ToArray(); } }
    public IReadOnlyCollection<ApplicationUser> Followers { get { return _followers.ToArray(); } }
    public readonly DateTime CreatedAt;

    public void ChangeVisibility() =>
        IsPublic = !IsPublic;

    public void AddMember(ApplicationUser member) =>
        _members.Add(member);

    public void RemoveMember(ApplicationUser member) =>
        _members.Remove(member);

    public void AddFollower(ApplicationUser follower) =>
        _followers.Add(follower);

    public void RemoveFollower(ApplicationUser follower) =>
        _followers.Remove(follower);

}


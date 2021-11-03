namespace Peep.Parrot.Domain.Entities;

public class Nest : Entity
{
    private readonly IList<User> _members;
    private readonly IList<User> _followers;

    public Nest(User owner, bool isPublic, string name, string description)
    {
        Owner = owner;
        IsPublic = isPublic;
        Name = name;
        Description = description;
        _members = new List<User>();
        _followers = new List<User>();
        CreatedAt = DateTime.Now;
    }

    public readonly User Owner;
    public bool IsPublic { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyCollection<User> Members { get { return _members.ToArray(); } }
    public IReadOnlyCollection<User> Followers { get { return _followers.ToArray(); } }
    public readonly DateTime CreatedAt;

    public void ChangeVisibility() =>
        IsPublic = !IsPublic;

    public void AddMember(User member) =>
        _members.Add(member);

    public void RemoveMember(User member) =>
        _members.Remove(member);

    public void AddFollower(User follower) =>
        _followers.Add(follower);

    public void RemoveFollower(User follower) =>
        _followers.Remove(follower);

}


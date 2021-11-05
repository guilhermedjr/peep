namespace Peep.Wings.Application.ViewModels;

public class ApplicationUserViewModel
{
    public readonly Guid Id;
    public readonly string Email;
    public readonly string Name;
    public readonly string Username;
    public readonly DateTime BirthDate;
    public readonly string ProfileImageUrl;
    public readonly DateTime JoinedAt;

    public ApplicationUserViewModel(Guid id, string email, string name, string username, DateTime birthDate, 
        string profileImageUrl, DateTime joinedAt)
    {
        Id = id;
        Email = email;
        Name = name;
        Username = username;
        BirthDate = birthDate;
        ProfileImageUrl = profileImageUrl;
        JoinedAt = joinedAt;
    }
}


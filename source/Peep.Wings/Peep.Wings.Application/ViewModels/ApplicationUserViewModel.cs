namespace Peep.Wings.Application.ViewModels;

public class ApplicationUserViewModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public DateTime BirthDate { get; set; }
    public string ProfileImageUrl { get; set; }
    public DateTime JoinedAt { get; set; }

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


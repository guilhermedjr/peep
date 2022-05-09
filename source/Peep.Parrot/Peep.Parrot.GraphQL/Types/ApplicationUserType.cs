namespace Peep.Parrot.GraphQL.Types;

public class ApplicationUserType : ObjectGraphType<ApplicationUser>
{
    public ApplicationUserType()
    {
        Name = "user";

        Field(u => u.Id);
        Field(u => u.Email);
        Field(u => u.Name);
        Field(u => u.Username);
        Field(u => u.ProfileImageUrl);
        Field(u => u.BirthDate);
        Field(u => u.JoinedAt);
        Field(u => u.Bio);
        Field(u => u.Location);
        Field(u => u.Website);
        Field(u => u.PrivateAccount);
        Field(u => u.VerifiedAccount);
        Field(u => u.Following);
        Field(u => u.Followers);
        Field(u => u.UserNests);
        Field(u => u.Nests);
        Field(u => u.FollowRequests);
        Field(u => u.BlockedUsers);
        Field(u => u.MutedUsers);
        Field(u => u.Peeps);
    }
}

public class ApplicationUserInputType : InputObjectGraphType<ApplicationUser>
{
    public ApplicationUserInputType() { }
}


namespace Peep.Parrot.GraphQL.Queries;

public class UsersQuery : ObjectGraphType
{
    public UsersQuery(IUsersRepository usersRepository)
    {
        Field<ApplicationUserType>(
            "GetUser",
            arguments: new QueryArguments(
                new QueryArgument<GuidGraphType>() { Name = "id" }
            ),
            resolve: context =>
            {
                return usersRepository.GetById(context.GetArgument<Guid>("id")).Result;
            }
        );
    }
}


namespace Peep.Parrot.GraphQL.Queries;

public class UsersQuery : ObjectGraphType
{
    public UsersQuery(IUsersRepository usersRepository, IPeepsRepository peepsRepository)
    {
        Field<ApplicationUserType>(
            "user",
            arguments: new QueryArguments(
                new QueryArgument<GuidGraphType> { Name = "id" }
            ),
            resolve: context =>
            {
                return usersRepository.GetById(context.GetArgument<Guid>("id")).Result;
            }
        );

        Field<ListGraphType<PeepType>>(
           "peeps",
           arguments: new QueryArguments(
               new QueryArgument<GuidGraphType> { Name = "userId" }
           ),
           resolve: context =>
           {
               return peepsRepository.GetUserPeeps(context.GetArgument<Guid>("userId")).Result;
           }
       );
    }
}


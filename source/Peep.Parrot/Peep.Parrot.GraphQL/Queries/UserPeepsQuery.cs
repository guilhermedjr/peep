namespace Peep.Parrot.GraphQL.Queries;

public class UserPeepsQuery : ObjectGraphType
{
    public UserPeepsQuery(IPeepsRepository peepsRepository)
    {
        Field<ListGraphType<PeepType>>(
            "GetUserPeeps",
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


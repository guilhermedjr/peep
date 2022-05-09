namespace Peep.Parrot.GraphQL.Queries;

public class PeepsQuery : ObjectGraphType
{
    public PeepsQuery(IPeepsRepository peepsRepository)
    {
        Field<PeepType>(
            "peep",
            arguments: new QueryArguments(
                new QueryArgument<GuidGraphType> { Name = "id" }
            ),
            resolve: context =>
            {
                return peepsRepository.GetById(context.GetArgument<Guid>("id")).Result;
            }
        );
    }
}


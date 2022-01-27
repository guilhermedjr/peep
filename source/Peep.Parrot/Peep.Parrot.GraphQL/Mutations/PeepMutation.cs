namespace Peep.Parrot.GraphQL.Mutations;

public class PeepMutation : ObjectGraphType<Domain.Entities.Peep>
{
    public PeepMutation(IPeepsRepository peepsRepository) 
    {
        Field<PeepType>(
            "AddPeep",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<PeepInputType>> { Name = "peep" }
            ),
            resolve: context =>
            {
                var peep = context.GetArgument<Domain.Entities.Peep>("peep");
                return peepsRepository.AddPeep(peep);
            }
        );
    }
}


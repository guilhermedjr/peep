namespace Peep.Parrot.GraphQL.Schemas;

public class PeepsSchema : Schema
{
    public PeepsSchema(IServiceProvider serviceProvider): base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<PeepsQuery>();
        Mutation = serviceProvider.GetRequiredService<PeepMutation>();
    }
}


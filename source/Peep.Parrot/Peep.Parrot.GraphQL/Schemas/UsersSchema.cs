namespace Peep.Parrot.GraphQL.Schemas;

public class UsersSchema : Schema
{
    public UsersSchema(IServiceProvider serviceProvider): base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<UsersQuery>();
    }
}


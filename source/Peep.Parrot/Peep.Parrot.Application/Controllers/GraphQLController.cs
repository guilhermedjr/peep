using Peep.Parrot.GraphQL.Schemas;
namespace Peep.Parrot.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GraphQLController : ControllerBase
{
    private readonly UsersSchema _usersSchema;

    public GraphQLController(UsersSchema usersSchema)
    {
        _usersSchema = usersSchema;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
    {
        var inputs = query.Variables.ToInputs();
    }
}

namespace Peep.Wings.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    // Test controller 
    private readonly ConnectionFactory _factory;
    private const string QUEUE_NAME = "wings_messages";

    public MessagesController()
    {
        _factory = new ConnectionFactory
        {
            HostName = "localhost"
        };
    }

    [HttpPost]
    public IActionResult PostCreatedAccountMessage([FromBody] ApplicationUserViewModel user)
    {
        using var connection = _factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: QUEUE_NAME,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var stringfiedMessage = JsonSerializer.Serialize(user);
        var bytesMessage = Encoding.UTF8.GetBytes(stringfiedMessage);

        channel.BasicPublish(
            exchange: "",
            routingKey: QUEUE_NAME,
            basicProperties: null,
            body: bytesMessage);

        return Accepted();
    }
}


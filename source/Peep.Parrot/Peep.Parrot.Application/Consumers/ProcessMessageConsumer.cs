using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Peep.Parrot.Application.ViewModels;

namespace Peep.Parrot.Application.Consumers;

public class MessageConsumptionService : BackgroundService
{
    private readonly IConfiguration _config;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    private readonly string queue;

    public MessageConsumptionService(IConfiguration config)
    {
        this._config = config;
        var factory = new ConnectionFactory
        {
            HostName = _config.GetSection("RabbitMQ")["Host"]
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        queue = _config.GetSection("RabbitMQ")["Queue"];

        _channel.QueueDeclare(
            queue: queue,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (sender, eventArgs) =>
        {
            var arrayContent = eventArgs.Body.ToArray();
            var stringContent = Encoding.UTF8.GetString(arrayContent);
            var message = JsonSerializer.Deserialize<ApplicationUserViewModel>(stringContent);

            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };

        _channel.BasicConsume(queue, false, consumer);

        return Task.CompletedTask;
    }
}


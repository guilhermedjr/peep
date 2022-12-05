using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Confluent.Kafka;
using Peep.EventBus.Events;
using Peep.EventBus.Subscriptions;
namespace Peep.EventBus.Kafka;

public class KafkaEventBus : IEventBus
{
    private readonly IEventBusSubscriptionsManager _subscriptionManager;
    private readonly ILogger<KafkaEventBus> _logger;
    private readonly KafkaConnection _kafkaConnection;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public KafkaEventBus(IEventBusSubscriptionsManager subscriptionManager, ILogger<KafkaEventBus> logger,
        KafkaConnection kafkaConnection, IServiceProvider serviceProvider)
    {
        _subscriptionManager = subscriptionManager ?? throw new ArgumentNullException(nameof(subscriptionManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _kafkaConnection = kafkaConnection ?? throw new ArgumentNullException(nameof(kafkaConnection));
        _serviceScopeFactory = serviceProvider?.GetRequiredService<IServiceScopeFactory>()
            ?? throw new ArgumentException($"Cannot resolve IServiceScopeFactory from {nameof(serviceProvider)}");
    }

    public async Task Publish<TEvent>(TEvent @event) where TEvent : Event
    {
        var eventType = typeof(TEvent).Name;

        try
        {
            var producer = _kafkaConnection.BuildProducer<TEvent>();
            var message = new Message<Null, TEvent>() { Value = @event };

            _logger.LogInformation($"Publishing event {@event.Id} of type {eventType} to Kafka topic: {@event}");

            var deliveryResult = await producer.ProduceAsync(eventType, message);

            _logger.LogInformation($"Event {@event.Id} of type {eventType} published to Kafka topic. Status: {deliveryResult.Status}");
        }

        catch (Exception ex)
        {
            _logger.LogError($"An error occured while publishing the event {@event.Id} of type {eventType} to Kafka topic");
            _logger.LogError(ex.Message + "\n" + ex.StackTrace);
        }
    }

    public async Task Subscribe<TEvent, TEventHandler>()
        where TEvent : Event
        where TEventHandler : IEventHandler<TEvent>
    {
        var eventName = typeof(TEvent).Name;

        using var consumer = _kafkaConnection.BuildConsumer<TEvent>();

        _subscriptionManager.AddSubscription<TEvent, TEventHandler>();
        consumer.Subscribe(eventName);

        await Task.Run(async () =>
        {
            while (true)
            {
                try
                {
                    _logger.LogInformation($"Consuming messages from topic {eventName}");
                    var consumeResult = consumer.Consume();
                    await ProcessEvent(consumeResult.Message.Value);
                }
                catch (ConsumeException ex)
                {
                    _logger.LogError($"Error `{ex.Error.Reason}` occured while consuming messages from topic {eventName}");
                    _logger.LogError(ex.Message + "\n" + ex.StackTrace);
                }
            }
        }).ConfigureAwait(false);
    }

    public Task Unsubscribe<TEvent, TEventHandler>()
        where TEvent : Event
        where TEventHandler : IEventHandler<TEvent>
    {
        throw new NotImplementedException();
    }

    private async Task<bool> ProcessEvent<TEvent>(TEvent @event) where TEvent : Event
    {
        var processed = false;
        var eventName = typeof(TEvent).Name;

        if (_subscriptionManager.HasSubscriptionsForEvent(eventName))
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var subscriptions = _subscriptionManager.GetSubscriptionsForEvent(eventName);
            foreach (var subscription in subscriptions)
            {
                var handler = scope.ServiceProvider.GetRequiredService(subscription.HandlerType);
                if (handler == null) continue;

                var concreteType = typeof(IEventHandler<>).MakeGenericType(typeof(TEvent));
                await (Task)concreteType.GetMethod("Handle").Invoke(handler, new[] { @event });
            }

            processed = true;
        }

        return processed;
    }
}
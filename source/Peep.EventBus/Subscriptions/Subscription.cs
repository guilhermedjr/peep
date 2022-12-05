using Autofac;
using System.Text.Json;
namespace Peep.EventBus.Subscriptions;

public class Subscription
{
    public Type HandlerType { get; }
    public Type EventType { get; }

    private Subscription(Type handlerType, Type eventType = null)
    {
        HandlerType = handlerType;
        EventType = eventType;
    }

    public static Subscription New(Type handlerType, Type eventType) =>
        new Subscription(handlerType, eventType);
}

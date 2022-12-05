using Peep.EventBus.Events;
namespace Peep.EventBus.Subscriptions;

public interface IEventBusSubscriptionsManager
{
    bool IsEmpty { get; }

    void AddSubscription<TEvent, TEventHandler>()
       where TEvent : Event
       where TEventHandler : IEventHandler<TEvent>;

    void RemoveSubscription<TEvent, TEventHandler>()
       where TEvent : Event
       where TEventHandler : IEventHandler<TEvent>;

    bool HasSubscriptionsForEvent(string eventName);
    IEnumerable<Subscription> GetSubscriptionsForEvent(string eventName);

    void Clear();
}
namespace Peep.EventBus.Subscriptions;

public class SubscriptionsManager : IEventBusSubscriptionsManager
{
    private readonly Dictionary<string, List<Subscription>> _eventSubscriptions;

    public SubscriptionsManager()
    {
        _eventSubscriptions = new Dictionary<string, List<Subscription>>();
    }

    public bool IsEmpty => !_eventSubscriptions.Any();
    public void Clear() => _eventSubscriptions.Clear();

    public void AddSubscription<TEvent, TEventHandler>()
       where TEvent : Event
       where TEventHandler : IEventHandler<TEvent>
    {
        var eventType = typeof(TEvent);
        var eventName = eventType.Name;
        var handlerType = typeof(TEventHandler);

        if (!HasSubscriptionsForEvent(eventName))
        {
            _eventSubscriptions.Add(eventName, new List<Subscription>());
        }

        if (_eventSubscriptions[eventName].Any(s => s.HandlerType == handlerType))
        {
            throw new ArgumentException(
                $"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
        }

        _eventSubscriptions[eventName].Add(Subscription.New(handlerType, eventType));
    }

    public void RemoveSubscription<TEvent, TEventHandler>()
        where TEvent : Event
        where TEventHandler : IEventHandler<TEvent>
    {
        var eventName = typeof(TEvent).Name;
        var handlerToRemove = FindSubscriptionToRemove<TEventHandler>(eventName);
        RemoveSubscription(eventName, handlerToRemove);
    }

    private Subscription FindSubscriptionToRemove<TEventHandler>(string eventName)
    {
        if (!HasSubscriptionsForEvent(eventName))
            return null;

        return _eventSubscriptions[eventName].SingleOrDefault(s => s.HandlerType == typeof(TEventHandler));
    }

    private void RemoveSubscription(string eventName, Subscription subscriptionToRemove)
    {
        if (subscriptionToRemove == null) return;

        _eventSubscriptions[eventName].Remove(subscriptionToRemove);

        if (_eventSubscriptions[eventName].Any()) return;

        _eventSubscriptions.Remove(eventName);
    }

    public bool HasSubscriptionsForEvent(string eventName) =>
        _eventSubscriptions.ContainsKey(eventName);

    public IEnumerable<Subscription> GetSubscriptionsForEvent(string eventName)
        => _eventSubscriptions[eventName];
}
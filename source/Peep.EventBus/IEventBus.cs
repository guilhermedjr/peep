using Peep.EventBus.Events;
namespace Peep.EventBus;

public interface IEventBus
{
    Task Publish<TEvent>(TEvent @event) 
        where TEvent : Event;

    Task Subscribe<TEvent, TEventHandler>()
        where TEvent : Event
        where TEventHandler : IEventHandler<TEvent>;

    Task Unsubscribe<TEvent, TEventHandler>()
        where TEvent : Event
        where TEventHandler : IEventHandler<TEvent>;
}
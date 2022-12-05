using Peep.EventBus.Events;
namespace Peep.EventBus;

public interface IEventHandler<TEvent> 
    where TEvent : Event
{
    Task Handle(TEvent @event);
}
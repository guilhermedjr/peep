namespace Peep.EventBus.Events;

public abstract class Event
{
    protected Event()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; }
    public DateTime CreatedAt { get; }
}

using System;
namespace Peep.Parrot.Shared.Entities;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}


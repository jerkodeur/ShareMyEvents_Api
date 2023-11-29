using Jerkoder.Common.Domain.EntityFramework.Interfaces;

namespace Jerkoder.Common.Domain.EntityFramework;

public abstract class Entity<TEntityId>: IEntity<TEntityId> where TEntityId : class
{
    public TEntityId? Id { get; init; }

    protected Entity()
    {
    }

    protected Entity(TEntityId id)
    {
        Id = id;
    }
}

public abstract class Entity: IEntity
{
    protected Entity ()
    {
    }
}

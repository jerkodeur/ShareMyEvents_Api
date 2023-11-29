using Jerkoder.Common.Domain.EntityFramework.Interfaces;

namespace Jerkoder.Common.Domain.EntityFramework;
public abstract class TrackedEntity: ITrackedEntity
{
    protected TrackedEntity ()
    {
    }

    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}

public abstract class TrackedEntity<TEntityId>: Entity<TEntityId>, ITrackedEntity<TEntityId> where TEntityId : class
{
    protected TrackedEntity()
    { 
    }

    protected TrackedEntity (TEntityId id) : base(id)
    {
    }

    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}

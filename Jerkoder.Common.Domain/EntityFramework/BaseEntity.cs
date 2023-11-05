using Jerkoder.Common.Domain.EntityFramework.Interfaces;

namespace Jerkoder.Common.Domain.EntityFramework;

public abstract class BaseEntity: IEntity
{
    
}

public class TrackedEntity: BaseEntity, ITrackedEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}

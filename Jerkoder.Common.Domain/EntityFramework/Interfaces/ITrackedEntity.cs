namespace Jerkoder.Common.Domain.EntityFramework.Interfaces;
public interface ITrackedEntity: IEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}

public interface ITrackedEntity<TEntityId>: IEntity<TEntityId>, ITrackedEntity
{
}

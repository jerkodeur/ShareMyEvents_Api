using Jerkoder.Common.Domain.EntityFramework.Interfaces;

namespace Jerkoder.Common.Domain.EntityFramework;

public class BaseEntity: IEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}

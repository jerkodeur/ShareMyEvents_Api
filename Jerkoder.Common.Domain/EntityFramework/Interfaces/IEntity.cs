﻿namespace Jerkoder.Common.Domain.EntityFramework.Interfaces;
public interface IEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}

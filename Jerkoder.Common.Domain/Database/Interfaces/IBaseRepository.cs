namespace Jerkoder.Common.Domain.Database.Interfaces;
public interface IBaseRepository<TEntity>
{
    Task Add (TEntity entity);
    void Update (TEntity entity);
    void Remove (TEntity entity);
}

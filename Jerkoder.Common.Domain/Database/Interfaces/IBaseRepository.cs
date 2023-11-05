namespace Jerkoder.Common.Domain.Database.Interfaces;
public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetOneByIdAsync(int id);
    Task Add (TEntity entity);
    void Update (TEntity entity);
    void Remove (TEntity entity);
}

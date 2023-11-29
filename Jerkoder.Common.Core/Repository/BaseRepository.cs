using Jerkoder.Common.Domain.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jerkoder.Common.Core.Repository;
public abstract class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DbSet<TEntity> _entityDbContext;
    protected readonly DbContext _context;

    protected BaseRepository (DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _entityDbContext = _context.Set<TEntity>() ??
            throw new NullReferenceException($"Internal error: null reference exception: {typeof(DbSet<TEntity>)}");
    }

    public async Task Add (TEntity entity)
    {
        await _entityDbContext.AddAsync(entity);
    }

    public void Update (TEntity entity)
    {
        _entityDbContext.Update(entity);
    }
    public void Remove (TEntity entity)
    {
        _entityDbContext.Remove(entity);
    }
}
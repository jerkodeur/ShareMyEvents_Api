using Jerkoder.Common.Domain.Database.Interfaces;
using Jerkoder.Common.Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Jerkoder.Common.Core.Repository;
public abstract class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> _entityDbContext;

    public BaseRepository (DbContext _context)
    {
        _entityDbContext = _context.Set<TEntity>() ?? 
            throw new NullReferenceException($"Internal error: null reference exception: {typeof(DbSet<TEntity>)}");
    }

    public async Task Add (TEntity entity)
    {
        await _entityDbContext.AddAsync(entity);
    }

    public async Task<List<TEntity>> GetAllAsync ()
    {
        return await _entityDbContext.ToListAsync();
    }

    public async Task<TEntity?> GetOneByIdAsync (int id)
    {
        return await _entityDbContext.FindAsync(id);
    }

    public void Remove (TEntity entity)
    {
        _entityDbContext.Remove(entity);
    }

    public void Update (TEntity entity)
    {
        _entityDbContext.Update(entity);
    }
}
using Jerkoder.Common.Core.Repository;
using Jerkoder.Common.Domain.Database.Interfaces;
using Jerkoder.Common.Domain.EntityFramework;

namespace ShareMyEvents.Api.Database.Repositories;

public abstract class GenericRepository<TEntity, TEntityId>: BaseRepository<TEntity>, IBaseRepository<TEntity>
    where TEntity : Entity<TEntityId>
    where TEntityId : StronglyTypeId
{
    protected GenericRepository (DbContext context)
        :base(context)
    {
    }

    public virtual async Task<TEntity?> GetOneByIdAsync (TEntityId id)
    {
        return await _entityDbContext.SingleOrDefaultAsync(e => e.Id == id);
    }
}

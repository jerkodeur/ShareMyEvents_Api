using Jerkoder.Common.Core.Repository;
using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Database.Repositories;

public class ActorRepository: BaseRepository<Actor>, IActorRepository
{
    public ActorRepository (DbContext _context) : base(_context)
    {
    }
}

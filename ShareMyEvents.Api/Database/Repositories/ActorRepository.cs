using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Database.Repositories;

internal sealed class ActorRepository: GenericRepository<Actor, ActorId>, IActorRepository
{
    public ActorRepository (ShareMyEventsApiContext _context) : base(_context)
    {
    }
}

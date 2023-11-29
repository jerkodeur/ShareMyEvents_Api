using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Database.Repositories;

internal sealed class EventRepository: GenericRepository<Event, EventId>, IEventRepository
{
    public EventRepository (ShareMyEventsApiContext context) : base(context)
    {
    }
}

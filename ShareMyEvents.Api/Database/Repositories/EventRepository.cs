using Jerkoder.Common.Core.Repository;
using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Database.Repositories;

public class EventRepository: BaseRepository<Event>, IEventRepository
{
    public EventRepository (DbContext context) : base(context)
    {
    }
}

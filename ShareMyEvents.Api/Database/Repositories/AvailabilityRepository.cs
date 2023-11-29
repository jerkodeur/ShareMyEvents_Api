using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Database.Repositories;

internal sealed class AvailabilityRepository: GenericRepository<Availability, AvailabilityId>, IAvailabilityRepository
{
    public AvailabilityRepository (ShareMyEventsApiContext _context) : base(_context)
    {
    }
}

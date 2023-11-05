using Jerkoder.Common.Core.Repository;
using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Database.Repositories;

public class AvailabilityRepository: BaseRepository<Availability>, IAvailabilityRepository
{
    public AvailabilityRepository (DbContext _context) : base(_context)
    {
    }
}

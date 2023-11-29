using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Database.Repositories;

internal sealed class AddressRepository: GenericRepository<Address, AddressId>, IAddressRepository
{
    public AddressRepository (ShareMyEventsApiContext _context) : base(_context)
    {
    }
}

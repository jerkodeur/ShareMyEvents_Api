using Jerkoder.Common.Core.Repository;
using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Database.Repositories;

public class AddressRepository: BaseRepository<Address>, IAddressRepository
{
    public AddressRepository (DbContext _context) : base(_context)
    {
    }
}

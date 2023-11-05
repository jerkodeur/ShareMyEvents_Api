using Jerkoder.Common.Core.Repository;
using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Database.Repositories;

public class UserRepository: BaseRepository<User>, IUserRepository
{
    public UserRepository (DbContext context) : base(context)
    {
    }
}


using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Database.Repositories;

internal sealed class UserRepository: GenericRepository<User, UserId>, IUserRepository
{
    public UserRepository (ShareMyEventsApiContext context) : base(context)
    {
    }
}


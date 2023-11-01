using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Domain.Interfaces;
public interface IAuthenticationService
{
    public Task<string> Authenticate (UserLoginRequest request);
}

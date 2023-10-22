using Newtonsoft.Json;
using ShareMyEvents.Domain.Dtos.Responses.UserResponses;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Domain.Interfaces;
public interface IAuthenticationService
{
    public Task<UserLoginResponse> Authenticate (UserLoginRequest request);
}

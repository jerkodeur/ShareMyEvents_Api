using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Responses.UserResponses;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Api.Requests.UserRequests;

public sealed record UserLogInQueryRequest: IQuery<UserLoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserLogInQueryRequest (UserLoginDto dto)
    {
        Email = dto.Email;
        Password = dto.Password;
    }
}

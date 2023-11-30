using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Api.Requests.UserRequests;

public class UserLogInQueryRequest: IQuery<Result<string>>
{
    public UserLoginDto Dto { get; }

    public UserLogInQueryRequest (UserLoginDto dto)
    {
        Dto = dto;
    }
}

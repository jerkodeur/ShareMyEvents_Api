using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Responses.UserResponses;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Api.Requests.UserRequests;

public class UserSignUpCommandRequest: ICommand<Result<UserSignUpResponse>>
{
    public UserSignUpDto Dto { get; }

    public UserSignUpCommandRequest (UserSignUpDto dto)
    {
        Dto = dto;
    }
}

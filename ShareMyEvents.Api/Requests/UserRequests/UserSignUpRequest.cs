using MediatR;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Api.Requests.UserRequests;

public class UserSignUpRequest: IRequest<User>
{
    public UserSignUpDto Dto { get; }

    public UserSignUpRequest (UserSignUpDto dto)
    {
        Dto = dto;
    }
}

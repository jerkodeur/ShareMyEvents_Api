using MediatR;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Api.Requests.UserRequests;

public class UserLostPasswordRequest: IRequest<User>
{
    public UserLostPasswordDto Dto { get; }

    public UserLostPasswordRequest (UserLostPasswordDto dto)
    {
        Dto = dto;
    }
}

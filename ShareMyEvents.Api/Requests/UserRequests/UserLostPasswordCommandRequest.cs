using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Api.Requests.UserRequests;

public class UserLostPasswordCommandRequest: ICommand
{
    public UserLostPasswordDto Dto { get; }

    public UserLostPasswordCommandRequest (UserLostPasswordDto dto)
    {
        Dto = dto;
    }
}

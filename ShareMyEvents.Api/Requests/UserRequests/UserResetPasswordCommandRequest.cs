using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Api.Requests.UserRequests;

public class UserResetPasswordCommandRequest: ICommand
{
    public UserResetPasswordDto Dto { get; }

    public UserResetPasswordCommandRequest (UserResetPasswordDto dto)
    {
        Dto = dto;
    }
}
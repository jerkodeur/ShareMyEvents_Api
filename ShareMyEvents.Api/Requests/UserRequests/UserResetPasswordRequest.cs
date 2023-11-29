using MediatR;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Api.Requests.UserRequests;

public class UserResetPasswordRequest: IRequest<User>
{
    public UserResetPasswordDto Dto { get; }

    public UserResetPasswordRequest (UserResetPasswordDto dto)
    {
        Dto = dto;
    }
}
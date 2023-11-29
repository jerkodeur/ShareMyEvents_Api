using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Api.Requests.UserRequests;

public class UserLogInQueryRequest: IQuery<Result<string>>
{
    public UserLoginQuery Command { get; }

    public UserLogInQueryRequest (UserLoginQuery command)
    {
        Command = command;
    }
}

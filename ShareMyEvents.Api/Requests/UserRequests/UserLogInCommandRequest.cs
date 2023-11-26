using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Api.Requests.UserRequests;

public class UserLogInCommandRequest: ICommand<string>
{
    public UserLoginCommand Command { get; }

    public UserLogInCommandRequest (UserLoginCommand command)
    {
        Command = command;
    }
}

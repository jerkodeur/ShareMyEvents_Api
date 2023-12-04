using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Api.Requests.UserRequests;

namespace ShareMyEvents.Api.Handlers.UserHandlers;

public class UserLostPasswordCommandHandler: ICommandHandler<UserLostPasswordCommandRequest>
{
    public Task<Result> Handle (UserLostPasswordCommandRequest request, CancellationToken cancellationToken) => throw new NotImplementedException();
}

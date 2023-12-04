using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Api.Requests.UserRequests;

namespace ShareMyEvents.Api.Handlers.UserHandlers;

public class UserResetPasswordCommandRequestHandler: ICommandHandler<UserResetPasswordCommandRequest>
{
    public Task<Result> Handle (UserResetPasswordCommandRequest request, CancellationToken cancellationToken) => throw new NotImplementedException();
}

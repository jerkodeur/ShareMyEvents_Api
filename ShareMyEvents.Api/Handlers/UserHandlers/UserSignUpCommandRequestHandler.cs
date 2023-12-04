using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Api.Requests.UserRequests;
using ShareMyEvents.Domain.Dtos.Responses.UserResponses;

namespace ShareMyEvents.Api.Handlers.UserHandlers;

public class UserSignUpCommandRequestHandler: ICommandHandler<UserSignUpCommandRequest, UserSignUpResponse>
{
    public Task<Result<UserSignUpResponse>> Handle (UserSignUpCommandRequest request, CancellationToken cancellationToken) => throw new NotImplementedException();
}

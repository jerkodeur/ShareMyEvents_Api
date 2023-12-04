using Jerkoder.Common.Domain.CQRS.Interfaces;
using Jerkoder.Common.Domain.Jwt.Interfaces;
using ShareMyEvents.Api.Requests.UserRequests;
using ShareMyEvents.Domain.Dtos.Responses.UserResponses;
using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Handlers.UserHandlers;

internal sealed class UserLoginQueryHandler: IQueryHandler<UserLogInQueryRequest, UserLoginResponse>
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtProvider<User> _jwtProvider;

    public UserLoginQueryHandler (IUserRepository userRepo, IJwtProvider<User> jwtProvider)
    {
        _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));
    }

    public async Task<Result<UserLoginResponse>> Handle (UserLogInQueryRequest request, CancellationToken cancellationToken)
    {
        Task.CompletedTask.Wait(100);

        var user = new User()
        {
            Id = new UserId(new Random().Next(1, 100)),
            Email = request.Email,
            Password = request.Password,
            Role = Domain.Enums.Role.IdentifiedUser
        };

        //var user = await _userRepo.GetUserAsync(request.Dto.Email, request.Dto.Password);

        //if(user == null)
        //{
        //    throw new UnauthorizedException(nameof(User));
        //}

        string token = _jwtProvider.GenerateToken(user!);

        var response = new UserLoginResponse(token);

        return response;
    }
}

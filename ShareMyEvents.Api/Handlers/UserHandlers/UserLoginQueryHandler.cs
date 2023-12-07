using FluentValidation;
using Jerkoder.Common.Domain.CQRS.Interfaces;
using Jerkoder.Common.Domain.Jwt.Interfaces;
using ShareMyEvents.Api.Requests.UserRequests;
using ShareMyEvents.Domain.Dtos.Responses.UserResponses;
using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Handlers.UserHandlers;

internal sealed class UserLoginQueryHandler: IQueryHandler<UserLogInQuery, UserLoginResponse>
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtProvider<User> _jwtProvider;
    private readonly IValidator<UserLogInQuery> _validator;

    public UserLoginQueryHandler (
        IUserRepository userRepo, 
        IJwtProvider<User> jwtProvider, 
        IValidator<UserLogInQuery> validator)
    {
        _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<Result<UserLoginResponse>> Handle (UserLogInQuery request, CancellationToken cancellationToken)
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

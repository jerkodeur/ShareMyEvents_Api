﻿using Jerkoder.Common.Domain.CQRS.Interfaces;
using Jerkoder.Common.Domain.Jwt.Interfaces;
using ShareMyEvents.Api.Requests.UserRequests;
using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Api.Handlers.UserHandlers;

internal sealed class UserLoginCommandHandler: ICommandHandler<UserLogInCommandRequest, string>
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtProvider<User> _jwtProvider;

    public UserLoginCommandHandler (IUserRepository userRepo, IJwtProvider<User> jwtProvider)
    {
        _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));
    }

    public async Task<Result<string>> HandleAsync (UserLogInCommandRequest request, CancellationToken cancellationToken)
    {
        Task.CompletedTask.Wait(100);

        var user = new User()
        {
            Id = new UserId(new Random().Next(1, 100)),
            Email = request.Command.Email,
            Password = request.Command.Password,
            Role = Domain.Enums.Role.IdentifiedUser
        };

        //var user = await _userRepo.GetUserAsync(request.Command.Email, request.Command.Password);

        //if(user == null)
        //{
        //    throw new UnauthorizedException(nameof(User));
        //}

        string token = _jwtProvider.GenerateToken(user!);

        return Result<string>.Success(token);
    }
}
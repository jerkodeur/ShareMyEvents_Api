using Jerkoder.Common.Domain.Jwt;
using Microsoft.EntityFrameworkCore;
using ShareMyEvents.Api.Data;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;
using ShareMyEvents.Domain.Entities;
using ShareMyEvents.Domain.Interfaces;

namespace ShareMyEvents.Api.Services;

internal sealed class AuthenticationService: IAuthenticationService
{
    private readonly ShareMyEventsApiContext _context;
    private readonly IJwtProvider<User> _jwtProvider;

    public AuthenticationService(ShareMyEventsApiContext context, IJwtProvider<User> jwtProvider)
    {
        _context = context ?? throw new NullReferenceException($"Internal error: null reference exception: {typeof(ShareMyEventsApiContext)}");
        _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));

        if(context.Users == null)
        {
            throw new NullReferenceException($"Internal error: null reference exception: {typeof(DbSet<User>)}");
        }
    }

    public async Task<string> Authenticate (UserLoginRequest RequestedUser)
    {
        var user = await getUserAsync(RequestedUser);

        //if(user == null)
        //{
        //    throw new UnauthorizedException(nameof(User));
        //}
        string token = _jwtProvider.GenerateToken(user!);

        return token;
    }

    private async Task<User?> getUserAsync(UserLoginRequest user)
    {
        Task.CompletedTask.Wait(100);

        return new User()
        {
            Email = user.Email,
            Password = user.password
        };
        //return await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.password);
    }
}

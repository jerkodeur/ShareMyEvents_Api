using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShareMyEvents.Api.Data;
using ShareMyEvents.Api.Exceptions;
using ShareMyEvents.Domain.Dtos.Responses.UserResponses;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;
using ShareMyEvents.Domain.Entities;
using ShareMyEvents.Domain.Interfaces;

namespace ShareMyEvents.Api.Services;

public class AuthenticationService: IAuthenticationService
{
    private readonly IConfiguration _configuration;
    private readonly ShareMyEventsApiContext _context;

    public AuthenticationService(IConfiguration configuration, ShareMyEventsApiContext context)
    {
        _configuration = configuration ?? throw new NullReferenceException($"Internal error: null reference exception: {typeof(IConfiguration)}");
        ;
        _context = context ?? throw new NullReferenceException($"Internal error: null reference exception: {typeof(ShareMyEventsApiContext)}");

        if(context.Users == null)
        {
            throw new NullReferenceException($"Internal error: null reference exception: {typeof(DbSet<User>)}");
        }
    }

    public async Task<UserLoginResponse> Authenticate (UserLoginRequest RequestedUser)
    {
        //var user = await getUserAsync(RequestedUser);

        //if(user == null)
        //{
        //    throw new UnauthorizedException(nameof(User));
        //}

        return GenerateToken("test");
    }

    private async Task<User?> getUserAsync(UserLoginRequest user)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.password);
    }

    private UserLoginResponse GenerateToken (string email) 
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, email)
        };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:ValidIssuer"],
            expires: DateTime.UtcNow.AddSeconds(Convert.ToInt32(_configuration["Jwt:TimeBeforeExpirationInSeconds"])),
            claims: claims,
            signingCredentials: new(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        var response = new UserLoginResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpireAt = token.ValidTo
        };

        return response;
    }
}

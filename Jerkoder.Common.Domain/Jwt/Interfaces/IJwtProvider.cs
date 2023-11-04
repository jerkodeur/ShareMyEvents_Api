namespace Jerkoder.Common.Domain.Jwt.Interfaces;
public interface IJwtProvider<in T> where T : class
{
    string GenerateToken(T user);
}

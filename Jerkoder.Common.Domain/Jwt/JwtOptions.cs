namespace Jerkoder.Common.Domain.Jwt;

public class JwtOptions
{
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public string SecretKey { get; init; } = string.Empty;
    public int ExpirationTimeInSeconds { get; set; }
}

namespace ShareMyEvents.Domain.Dtos.Responses.UserResponses;
public class UserLoginResponse
{
    public required string Token { get; set; }
    public required DateTime ExpireAt { get; set; }
}

namespace ShareMyEvents.Domain.Dtos.Responses.UserResponses;
public class UserSignUpResponse
{
    public required string UserId { get; set; }

    public required string Email { get; set; }

    public required string Nickname { get; set; }
}

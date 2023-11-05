using Jerkoder.Common.Domain.EntityFramework;
using ShareMyEvents.Domain.Enums;

namespace ShareMyEvents.Domain.Entities;

public class User : TrackedEntity
{
    public UserId? Id { get; init; }

    public required string Email { get; set; }
    public required string Password { get; set; }

    public required Role Role { get; set; }
}

public record UserId (int Value);
using Jerkoder.Common.Domain.EntityFramework;

namespace ShareMyEvents.Domain.Entities;

public class Actor: TrackedEntity<ActorId>
{
    public required string Nickname { get; set; }
    public required string Email { get; set; }

    public UserId? userId { get; set; }
    public User? User { get; set; }

    public List<Participation> Participations { get; set; } = new();
}

public record ActorId(int Value): StronglyTypeId;

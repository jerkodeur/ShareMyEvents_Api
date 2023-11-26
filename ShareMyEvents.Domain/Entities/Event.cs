using Jerkoder.Common.Domain.EntityFramework;

namespace ShareMyEvents.Domain.Entities;

public class Event: TrackedEntity<EventId>
{
    public required Code Code { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime EventDate { get; set; }

    public required ActorId OrganizerId { get; set; }

    public Address Address { get; set; } = null!;
    public required Actor Organizer { get; set; }

    public List<Participation> Participations { get; set; } = new ();
}

public record EventId (int Value): StronglyTypeId;

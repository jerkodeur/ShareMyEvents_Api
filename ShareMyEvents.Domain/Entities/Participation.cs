using Jerkoder.Common.Domain.EntityFramework;

namespace ShareMyEvents.Domain.Entities;

public class Participation: TrackedEntity
{
    public required ActorId ActorId { get; set; }
    public required EventId EventId { get; init; }
    public required AvailabilityId AvailabilityId { get; set; }

    public required Actor Participant { get; set; }
    public required Event Event { get; set; }
    public required Availability Availability { get; set; }
}

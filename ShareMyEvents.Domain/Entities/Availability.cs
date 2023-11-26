using Jerkoder.Common.Domain.EntityFramework;

namespace ShareMyEvents.Domain.Entities;

public class Availability: Entity<AvailabilityId>
{
    public Availability (AvailabilityId id) : base(id)
    {
    }

    public required Enums.Availability Label { get; set; } = Enums.Availability.Available;

    public List<Participation> Participations { get; set; } = new();
}

public record AvailabilityId (int Value): StronglyTypeId;

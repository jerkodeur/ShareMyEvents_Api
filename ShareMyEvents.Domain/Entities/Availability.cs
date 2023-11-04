using Jerkoder.Common.Domain.EntityFramework.Interfaces;

namespace ShareMyEvents.Domain.Entities;

public class Availability: BaseEntity
{
    public AvailabilityId? Id { get; init; }

    public required Enums.Availability Label { get; set; } = Enums.Availability.Available;

    public List<Participation> Participations { get; set; } = new();
}

public record AvailabilityId (int Value);

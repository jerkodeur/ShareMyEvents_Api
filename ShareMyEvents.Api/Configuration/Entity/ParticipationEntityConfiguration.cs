using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShareMyEvents.Api.Configuration.Entity;

public class ParticipationEntityConfiguration: IEntityTypeConfiguration<Participation>
{
    public void Configure (EntityTypeBuilder<Participation> builder)
    {
        builder.ToTable(nameof(Participation));

        builder.HasKey(p => new {p.EventId, p.ActorId, p.AvailabilityId});

        builder.Property(p => p.ActorId).HasConversion(
            Id => Id.Value,
            value => new ActorId(value));

        builder.Property(p => p.EventId).HasConversion(
            Id => Id.Value,
            value => new EventId(value));

        builder.Property(p => p.AvailabilityId).HasConversion(
            Id => Id.Value,
            value => new AvailabilityId(value));
    }
}

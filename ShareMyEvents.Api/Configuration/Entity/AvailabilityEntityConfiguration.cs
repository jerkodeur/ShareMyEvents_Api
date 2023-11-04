using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShareMyEvents.Api.Configuration.Entity;

internal class AvailabilityEntityConfiguration: IEntityTypeConfiguration<Availability>
{
    public void Configure (EntityTypeBuilder<Availability> builder)
    {
        builder.ToTable(nameof(Availability));

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            Id => Id!.Value,
            value => new AvailabilityId(value));

        builder.Property(a => a.Label).HasMaxLength(255).IsRequired();

        builder.HasIndex(a => a.Label).IsUnique();
    }
}

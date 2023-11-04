using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShareMyEvents.Api.Configuration.Entity;

internal class EventEntityConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure (EntityTypeBuilder<Event> builder)
    {
        builder.ToTable(nameof(Event));

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).HasMaxLength(255).IsRequired();
        builder.Property(e => e.Title).HasMaxLength(255).IsRequired();
        builder.Property(e => e.Description).IsRequired();
        builder.Property(e => e.EventDate).IsRequired();

        builder.Property(e => e.Id).HasConversion(
            Id => Id!.Value,
            value => new EventId(value));

        builder.Property(e => e.Code).HasConversion(
            Code => Code!.Value,
            value => new Code(value));

        builder.Property(e => e.OrganizerId).HasConversion(
            Id => Id.Value,
            value => new ActorId(value));

        builder.HasOne(e => e.Organizer)
            .WithMany()
            .HasForeignKey(e => e.OrganizerId)
            .IsRequired();

        builder.HasOne(e => e.Address)
            .WithOne(a => a.Event)
            .HasForeignKey<Address>("EventId")
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);

        builder.HasIndex(e => e.Code).IsUnique();
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShareMyEvents.Api.Configuration.Entity;

internal class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure (EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address));

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            Id => Id.Value,
            value => new AddressId(value));

        builder.HasOne(a => a.Event)
            .WithOne(e => e.Address)
            .HasForeignKey<Address>("EventId")
            .IsRequired();

        builder.Property(a => a.Street).HasMaxLength(255).IsRequired();
        builder.Property(a => a.PostalCode).HasMaxLength(255).IsRequired();
        builder.Property(a => a.City).HasMaxLength(255).IsRequired();
        builder.Property(a => a.Additional).IsRequired();
    }
}

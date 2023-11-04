using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShareMyEvents.Api.Configuration.Entity;

internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure (EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof (User));

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasConversion(
            Id => Id!.Value,
            value => new UserId(value));

        builder.Property(u => u.Email).HasMaxLength (255).IsRequired();
        builder.Property(u => u.Password).HasMaxLength (255).IsRequired();
        builder.Property(u => u.Role).HasMaxLength (255).IsRequired();

        builder.HasIndex(u => u.Email).IsUnique();
    }
}

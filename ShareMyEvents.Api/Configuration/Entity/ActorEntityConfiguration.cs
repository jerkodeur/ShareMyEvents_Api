using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShareMyEvents.Api.Configuration.Entity;

internal class ActorEntityConfiguration: IEntityTypeConfiguration<Actor>
{
    public void Configure (EntityTypeBuilder<Actor> builder)
    {
        builder.ToTable(nameof (Actor));

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            Id => Id!.Value,
            value => new ActorId(value));

        builder.Property(u => u.userId).HasConversion(
            Id => Id!.Value,
            value => new UserId(value));

        builder.Property(a => a.Nickname).HasMaxLength (255).IsRequired();
        builder.Property(a => a.Email).HasMaxLength (255).IsRequired();

        builder.HasIndex(a => a.Email).IsUnique();
    }
}

using Jerkoder.Common.Domain.EntityFramework;
using ShareMyEvents.Api.Configuration.Entity;

namespace ShareMyEvents.Api.Data
{
    public class ShareMyEventsApiContext : DbContext
    {
        public ShareMyEventsApiContext (DbContextOptions<ShareMyEventsApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Actor> Actors { get; set; } = default!;
        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<Availability> Availabilities{ get; set; } = default!;
        public DbSet<Participation> Participations { get; set; } = default!;

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ActorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EventEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AvailabilityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipationEntityConfiguration());
        }

        public override int SaveChanges (bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync (
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving ()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach(var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if(entry.Entity is BaseEntity trackable)
                {
                    switch(entry.State)
                    {
                        case EntityState.Modified:
                        // set the updated date to "now"
                        trackable.UpdatedOn = utcNow;

                        // mark property as "don't touch"
                        // we don't want to update on a Modify operation
                        entry.Property("CreatedOn").IsModified = false;
                        break;

                        case EntityState.Added:
                        // set both updated and created date to "now"
                        trackable.CreatedOn = utcNow;
                        trackable.UpdatedOn = utcNow;
                        break;
                    }
                }
            }
        }
    }
}

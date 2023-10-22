using Microsoft.EntityFrameworkCore;
using ShareMyEvents.Domain.Entities;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Api.Data
{
    public class ShareMyEventsApiContext : DbContext
    {
        public ShareMyEventsApiContext (DbContextOptions<ShareMyEventsApiContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<Participation> Participations { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<Actor> Actors { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Availability> Availabilities{ get; set; } = default!;
    }
}

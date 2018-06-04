using FamilySite.Data.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FamilySite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<InviteAnswer>()
                .HasOne(o => o.Invite)
                .WithOne(b => b.InviteAnswer)
                .HasForeignKey<InviteAnswer>(b => b.InviteId);
        }

        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<InviteAnswer> InviteAnswers { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}

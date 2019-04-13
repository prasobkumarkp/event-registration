using EventRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace EventRegistration.Data
{
    public class EventRegistrationDbContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Registration> EventRegistrations { get; set; }
        public DbSet<Day> EventDays { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public EventRegistrationDbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BridgeRegistrationDay>().HasKey(k => new {k.DayId, k.RegistrationId});
        }
    }
}

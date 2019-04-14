using EventRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace EventRegistration.Data
{
    public class EventRegistrationDbContext : DbContext
    {

        public DbSet<Day> Day { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<RegistrationDay> RegistrationDay { get; set; }
        public DbSet<User> User { get; set; }

        public EventRegistrationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Day>(entity =>
            {
                entity.Property(e => e.Label)
                    .IsRequired();
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Label)
                    .IsRequired();

                entity.Property(e => e.Value)
                    .IsRequired();
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.AdditionalRequest);

                entity.Property(e => e.DateRegistered).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registration_User");
            });

            modelBuilder.Entity<RegistrationDay>(entity =>
            {
                entity.HasOne(d => d.EventDay)
                    .WithMany(p => p.RegistrationDays)
                    .HasForeignKey(d => d.EventDayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegistrationDays_EventDays");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.RegistrationDay)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegistrationDays_Registration");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Gender");
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Models
{
    public partial class marathonseContext : DbContext
    {
        public marathonseContext()
        {
        }

        public marathonseContext(DbContextOptions<marathonseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Charity> Charity { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Marathon> Marathon { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<RaceKitOption> RaceKitOption { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<RegistrationEvent> RegistrationEvent { get; set; }
        public virtual DbSet<RegistrationStatus> RegistrationStatus { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Runner> Runner { get; set; }
        public virtual DbSet<Sponsorship> Sponsorship { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Timesheet> Timesheet { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Volunteer> Volunteer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Charity>(entity =>
            {
                entity.Property(e => e.CharityDescription).HasMaxLength(2000);

                entity.Property(e => e.CharityLogo).HasMaxLength(50);

                entity.Property(e => e.CharityName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryCode)
                    .HasName("pk_Country");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.CountryFlag)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId)
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EventTypeId)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__EventType__74AE54BC");

                entity.HasOne(d => d.Marathon)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.MarathonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__MarathonI__75A278F5");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.Property(e => e.EventTypeId)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.EventTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Gender1)
                    .HasName("pk_Gender");

                entity.Property(e => e.Gender1)
                    .HasColumnName("Gender")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Marathon>(entity =>
            {
                entity.Property(e => e.MarathonId).ValueGeneratedOnAdd();

                entity.Property(e => e.CityName).HasMaxLength(80);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.MarathonName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Marathon)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Marathon__Countr__7A672E12");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).ValueGeneratedOnAdd();

                entity.Property(e => e.Payrate).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PositionDescription).HasMaxLength(1000);

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RaceKitOption>(entity =>
            {
                entity.Property(e => e.RaceKitOptionId)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RaceKitOption1)
                    .IsRequired()
                    .HasColumnName("RaceKitOption")
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RaceKitOptionId)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.RegistrationDateTime).HasColumnType("datetime");

                entity.Property(e => e.SponsorshipTarget).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.CharityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Chari__71D1E811");

                entity.HasOne(d => d.RaceKitOption)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.RaceKitOptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__RaceK__6FE99F9F");

                entity.HasOne(d => d.RegistrationStatus)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.RegistrationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Regis__70DDC3D8");

                entity.HasOne(d => d.Runner)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.RunnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Runne__6A30C649");
            });

            modelBuilder.Entity<RegistrationEvent>(entity =>
            {
                entity.Property(e => e.EventId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.RegistrationEvent)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Event__797309D9");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.RegistrationEvent)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Regis__778AC167");
            });

            modelBuilder.Entity<RegistrationStatus>(entity =>
            {
                entity.Property(e => e.RegistrationStatusId).ValueGeneratedOnAdd();

                entity.Property(e => e.RegistrationStatus1)
                    .IsRequired()
                    .HasColumnName("RegistrationStatus")
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Runner>(entity =>
            {
                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Runner)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Runner__CountryC__5535A963");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Runner)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Runner__Email__7C4F7684");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Runner)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Runner__Gender__7D439ABD");
            });

            modelBuilder.Entity<Sponsorship>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SponsorName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.Sponsorship)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sponsorsh__Regis__72C60C4A");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.Comments).HasMaxLength(2000);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.Postion)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.PostionId)
                    .HasConstraintName("FK_Staff_Position_PositionId");
            });

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.PayAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("pk_User");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(80);

                entity.Property(e => e.LastName).HasMaxLength(80);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__RoleId__7B5B524B");
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.FirstName).HasMaxLength(80);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.LastName).HasMaxLength(80);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Volunteer)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__Count__571DF1D5");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Volunteer)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__Gende__5629CD9C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovaTrack.Shared.Domain.Repositories;
using NovaTrack.IAM.Domain.Model.Aggregates;
using NovaTrack.FleetManagement.Domain.Model.Aggregates;
using NovaTrack.Personnel.Domain.Model.Aggregates;
using NovaTrack.Maintenance.Domain.Model.Aggregates;
using NovaTrack.Maintenance.Domain.Model.ValueObjects;

// ApplicationDbContext.cs
namespace NovaTrack.Shared.Infrastructure.Persistence.EFC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // IAM DbSets
        public DbSet<User> Users { get; set; } = null!;

        // FleetManagement DbSets
        public DbSet<Fleet> Fleets { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;

        // Personnel DbSets
        public DbSet<Driver> Drivers { get; set; } = null!;

        // Maintenance DbSets
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; } = null!;
        public DbSet<ServiceRecord> ServiceRecords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure IAM entities
            ConfigureIAMEntities(modelBuilder);

            // Configure FleetManagement entities
            ConfigureFleetManagementEntities(modelBuilder);

            // Configure Personnel entities
            ConfigurePersonnelEntities(modelBuilder);

            // Configure Maintenance entities
            ConfigureMaintenanceEntities(modelBuilder);
        }

        private static void ConfigureIAMEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Role).IsRequired().HasMaxLength(50);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime(6)")
                    .ValueGeneratedNever();
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime(6)")
                    .ValueGeneratedNever();
            });
        }

        private static void ConfigureFleetManagementEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fleet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Code).IsRequired().HasMaxLength(20);
                entity.HasIndex(e => e.Code).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Type).HasConversion<string>();
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime(6)")
                    .ValueGeneratedNever();
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime(6)")
                    .ValueGeneratedNever();

                entity.HasMany(e => e.Vehicles)
                      .WithOne(v => v.Fleet)
                      .HasForeignKey(v => v.FleetId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Brand).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Model).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.Mileage).HasDefaultValue(0);
                entity.Property(e => e.Status).HasConversion<string>();
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime(6)")
                    .ValueGeneratedNever();
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime(6)")
                    .ValueGeneratedNever();

                // Configure LicensePlate value object
                entity.OwnsOne(e => e.LicensePlate, licensePlate =>
                {
                    licensePlate.Property(lp => lp.Value)
                               .HasColumnName("LicensePlate")
                               .IsRequired()
                               .HasMaxLength(20);
                    licensePlate.HasIndex(lp => lp.Value).IsUnique();
                });
            });
        }

        private static void ConfigurePersonnelEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Code).IsRequired().HasMaxLength(20);
                entity.HasIndex(e => e.Code).IsUnique();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ExperienceYears).HasDefaultValue(0);
                entity.Property(e => e.Status).HasConversion<string>();
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime(6)")
                    .ValueGeneratedNever();
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime(6)")
                    .ValueGeneratedNever();

                // Configure DriverLicense value object
                entity.OwnsOne(e => e.License, license =>
                {
                    license.Property(l => l.Number)
                          .HasColumnName("LicenseNumber")
                          .IsRequired()
                          .HasMaxLength(50);
                    license.Property(l => l.ExpiryDate)
                          .HasColumnName("LicenseExpiryDate")
                          .IsRequired();
                    license.HasIndex(l => l.Number).IsUnique();
                });

                // Configure ContactInformation value object
                entity.OwnsOne(e => e.ContactInfo, contact =>
                {
                    contact.Property(c => c.Phone)
                          .HasColumnName("Phone")
                          .HasMaxLength(15);
                    contact.Property(c => c.Email)
                          .HasColumnName("Email")
                          .HasMaxLength(255);
                });
            });
        }

        private static void ConfigureMaintenanceEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaintenanceRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.VehicleId).IsRequired();
                entity.Property(e => e.Description).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Type).HasConversion<string>();
                entity.Property(e => e.Status).HasConversion<string>();
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.ServiceProvider).HasMaxLength(200);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime(6)")
                    .ValueGeneratedNever();
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime(6)")
                    .ValueGeneratedNever();

                // Configure MaintenanceCost value object
                entity.OwnsOne(e => e.Cost, cost =>
                {
                    cost.Property(c => c.EstimatedAmount)
                        .HasColumnName("EstimatedCost")
                        .HasColumnType("decimal(10,2)")
                        .IsRequired();
                    cost.Property(c => c.ActualAmount)
                        .HasColumnName("ActualCost")
                        .HasColumnType("decimal(10,2)");
                    cost.Property(c => c.Currency)
                        .HasColumnName("Currency")
                        .HasMaxLength(3)
                        .HasDefaultValue("PEN");
                });

                // Configure MaintenanceSchedule value object
                entity.OwnsOne(e => e.Schedule, schedule =>
                {
                    schedule.Property(s => s.ScheduledDate)
                           .HasColumnName("ScheduledDate")
                           .IsRequired();
                    schedule.Property(s => s.CompletedDate)
                           .HasColumnName("CompletedDate");
                    schedule.Property(s => s.Priority)
                           .HasColumnName("Priority")
                           .HasDefaultValue(3);
                });
            });

            modelBuilder.Entity<ServiceRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.VehicleId).IsRequired();
                entity.Property(e => e.ServiceType).HasConversion<string>();
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.ServiceDate).IsRequired();
                entity.Property(e => e.MileageAtService).IsRequired();
                entity.Property(e => e.ServiceProvider).IsRequired().HasMaxLength(200);
                entity.Property(e => e.TechnicianName).HasMaxLength(100);
                entity.Property(e => e.Quality).HasConversion<string>();
                entity.Property(e => e.PartsUsed).HasMaxLength(1000);
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime(6)")
                    .ValueGeneratedNever();

                // Configure ServiceCost value object
                entity.OwnsOne(e => e.Cost, cost =>
                {
                    cost.Property(c => c.Amount)
                        .HasColumnName("Cost")
                        .HasColumnType("decimal(10,2)")
                        .IsRequired();
                    cost.Property(c => c.Currency)
                        .HasColumnName("Currency")
                        .HasMaxLength(3)
                        .HasDefaultValue("PEN");
                    cost.Property(c => c.Type)
                        .HasConversion<string>();


                    // Guardar los CostItems como JSON
                    cost.Property(c => c.Items)
                        .HasConversion(
                            v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                            v => JsonSerializer.Deserialize<List<CostItem>>(v, new JsonSerializerOptions())!
                        )
                        .HasColumnName("CostItems")
                        .HasColumnType("json");
                });
            });
        }
    }
}

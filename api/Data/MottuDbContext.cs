using Microsoft.EntityFrameworkCore;
using mottu;
using mottu.Models;
using Mottu.Models;

namespace Mottu.Data;

public class MottuDbContext(DbContextOptions<MottuDbContext> options) : DbContext(options)
{
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Rider> Riders { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalPlan> RentalPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Rental>()
            .HasOne(r => r.Bike)
            .WithMany(b => b.Rentals)
            .HasForeignKey(r => r.RiderId);

        modelBuilder.Entity<Rental>().HasOne(r => r.Plan).WithMany().HasForeignKey(r => r.PlanId);
        modelBuilder.Entity<Rental>().HasOne(r => r.Rider).WithMany().HasForeignKey(r => r.RiderId);

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Bike>()
            .HasData(
                new Bike
                {
                    Id = 1,
                    Model = "Yamaha V10 Tracker",
                    Year = 2020,
                    Plate = "ABC1234"
                },
                new Bike
                {
                    Id = 2,
                    Model = "Honda CB 500",
                    Year = 2021,
                    Plate = "DEF5678"
                },
                new Bike
                {
                    Id = 3,
                    Model = "Suzuki GSX 750",
                    Year = 2019,
                    Plate = "GHI9101"
                }
            );

        modelBuilder
            .Entity<RentalPlan>()
            .HasData(
                new RentalPlan
                {
                    Id = 1,
                    DaysDuration = 7,
                    PricePerDay = 3000,
                    UnusedDayPrice = 600,
                    OverdueDayPrice = 5000,
                },
                new RentalPlan
                {
                    Id = 2,
                    DaysDuration = 15,
                    PricePerDay = 2800,
                    UnusedDayPrice = 1120,
                    OverdueDayPrice = 5000,
                },
                new RentalPlan
                {
                    Id = 3,
                    DaysDuration = 30,
                    PricePerDay = 2200,
                    UnusedDayPrice = 1320,
                    OverdueDayPrice = 5000,
                }
            );

        modelBuilder
            .Entity<Rider>()
            .HasData(
                new Rider
                {
                    Id = 1,
                    Name = "John Doe",
                    Cnpj = "12345678900000",
                    Birthdate = new DateTime(1990, 1, 1),
                    CnhNumber = "1234567890",
                    CnhType = CnhType.A,
                    CnhPhotoUrl = "https://example.com/cnh-photo.jpg"
                },
                new Rider
                {
                    Id = 2,
                    Name = "Jane Doe",
                    Cnpj = "12345678900001",
                    Birthdate = new DateTime(1990, 1, 1),
                    CnhNumber = "1234567891",
                    CnhType = CnhType.A,
                    CnhPhotoUrl = "https://example.com/cnh-photo.jpg"
                }
            );
    }
}

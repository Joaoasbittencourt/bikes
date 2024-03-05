using Microsoft.EntityFrameworkCore;
using mottu;
using Mottu.Models;

namespace Mottu.Data;

public class MottuDbContext(DbContextOptions<MottuDbContext> options) : DbContext(options)
{
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Rider> Riders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}

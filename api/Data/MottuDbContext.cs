using Microsoft.EntityFrameworkCore;
using Mottu.Models;

namespace Mottu.Data;

public class MottuDbContext(DbContextOptions<MottuDbContext> options) : DbContext(options)
{
    public DbSet<Bike> Bikes { get; set; }
}

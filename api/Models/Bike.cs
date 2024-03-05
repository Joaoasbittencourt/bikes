namespace Bikes.Models;

using System.ComponentModel.DataAnnotations;
using bikes.Models;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Plate), IsUnique = true)]
public class Bike
{
    [Key]
    public int Id { get; set; }
    public int Year { get; set; }
    public required string Model { get; set; }
    public required string Plate { get; set; }

    public ICollection<Rental> Rentals { get; } = [];
}

namespace Mottu.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using mottu.Models;

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

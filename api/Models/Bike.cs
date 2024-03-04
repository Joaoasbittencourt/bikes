namespace Mottu.Models;

using System.ComponentModel.DataAnnotations;

public class Bike
{
    [Key]
    public int Id { get; set; }
    public int Year { get; set; }
    public string Model { get; set; }
    public string Identifier { get; set; }
    public string Plate { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

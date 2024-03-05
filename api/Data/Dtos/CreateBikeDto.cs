using System.ComponentModel.DataAnnotations;

namespace Bikes.Data.Dtos;

public class CreateBikeDto
{
    [Required]
    [Range(1900, 2100)]
    public required int Year { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string Model { get; set; }

    [Required]
    [StringLength(7, MinimumLength = 7)]
    public required string Plate { get; set; }
}

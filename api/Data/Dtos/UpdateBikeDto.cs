using System.ComponentModel.DataAnnotations;

namespace Bikes.Data.Dtos;

public class UpdateBikeDto
{
    [StringLength(7, MinimumLength = 7)]
    public string? Plate { get; set; }
}

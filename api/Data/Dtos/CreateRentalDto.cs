using System.ComponentModel.DataAnnotations;

namespace Mottu.Data.Dtos;

public class CreateRentalDto
{
    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public required int RiderId { get; set; }

    [Required]
    public required int BikeId { get; set; }

    [Required]
    public int PlanId { get; set; }
}

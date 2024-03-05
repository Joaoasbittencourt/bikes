using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mottu.Models;

namespace mottu.Models;

public class Rental
{
    [Key]
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public required int RiderId { get; set; }
    public required Rider Rider { get; set; }

    public required int BikeId { get; set; }
    public required Bike Bike { get; set; }

    public int PlanId { get; set; }
    public required RentalPlan Plan { get; set; }

    [NotMapped]
    public int TotalPrice
    {
        get { return GetTotalPrice(); }
    }

    private int GetTotalPrice()
    {
        var usedDays = (EndDate - StartDate).TotalDays;
        var planDays = Plan.DaysDuration;

        if (usedDays < planDays)
        {
            var remainingDays = planDays - usedDays;
            return (int)(usedDays * Plan.PricePerDay + remainingDays * Plan.UnusedDayPrice);
        }
        else if (usedDays > planDays)
        {
            var overdueDays = usedDays - planDays;
            return (int)(planDays * Plan.PricePerDay + overdueDays * Plan.OverdueDayPrice);
        }
        else
        {
            return planDays * Plan.PricePerDay;
        }
    }
}

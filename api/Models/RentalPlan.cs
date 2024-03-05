using System.ComponentModel.DataAnnotations;

namespace bikes.Models;

public class RentalPlan
{
    [Key]
    public int Id { get; set; }
    public int DaysDuration { get; set; }
    public int PricePerDay { get; set; }
    public int UnusedDayPrice { get; set; }
    public int OverdueDayPrice { get; set; }
}

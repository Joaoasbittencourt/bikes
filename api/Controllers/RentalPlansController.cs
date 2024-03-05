using Bikes.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bikes.Controllers;

[ApiController]
[Route("rental-plans")]
public class RentalPlansController(BikesDbContext context) : Controller
{
    private readonly BikesDbContext _context = context;

    [HttpGet]
    public IActionResult List()
    {
        return Ok(_context.RentalPlans);
    }
}

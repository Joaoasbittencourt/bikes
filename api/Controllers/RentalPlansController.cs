using Microsoft.AspNetCore.Mvc;
using Mottu.Data;

namespace Mottu.Controllers;

[ApiController]
[Route("rental-plans")]
public class RentalPlansController(MottuDbContext context) : Controller
{
    private readonly MottuDbContext _context = context;

    [HttpGet]
    public IActionResult List()
    {
        return Ok(_context.RentalPlans);
    }
}

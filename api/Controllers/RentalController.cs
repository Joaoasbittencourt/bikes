using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mottu;
using Mottu.Data;
using Mottu.Data.Dtos;
using mottu.Models;

namespace Mottu.Controllers;

[ApiController]
[Route("rentals")]
public class RentalController(MottuDbContext context) : Controller
{
    private readonly MottuDbContext _context = context;

    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var rental = _context.Rentals.Find(id);
        return rental == null ? NotFound() : Ok(rental);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateRentalDto dto)
    {
        var bike = _context
            .Bikes.Where(b => b.Id == dto.BikeId)
            .Include(b => b.Rentals.Where(r => r.EndDate > DateTime.Now))
            .FirstOrDefault();

        if (bike == null)
        {
            return BadRequest("Bike not found");
        }

        if (bike.Rentals.Count != 0)
        {
            return BadRequest("Bike is already rented");
        }

        var rider = _context.Riders.Find(dto.RiderId);
        if (rider == null)
        {
            return BadRequest("Rider not found");
        }
        if (rider.CnhType != CnhType.A)
        {
            return BadRequest("Rider must have a type A CNH to rent a bike");
        }

        var plan = _context.RentalPlans.Find(dto.PlanId);
        if (plan == null)
        {
            return BadRequest("Plan not found");
        }

        var rental = new Rental
        {
            StartDate = DateTime.Now,
            EndDate = dto.EndDate,
            RiderId = dto.RiderId,
            Rider = rider,
            BikeId = dto.BikeId,
            Bike = bike,
            PlanId = dto.PlanId,
            Plan = plan
        };

        _context.Rentals.Add(rental);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetOne), new { id = rental.Id }, rental);
    }
}

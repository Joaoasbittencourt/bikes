using Bikes.Data;
using Bikes.Data.Dtos;
using Bikes.Data.Queries;
using Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bikes.Controllers;

[ApiController]
[Route("bikes")]
public class BikeController(BikesDbContext context) : Controller
{
    private readonly BikesDbContext _context = context;

    [HttpGet]
    public IActionResult List([FromQuery] GetBikesQuery query)
    {
        var bikes = _context.Bikes.Skip(query.Skip).Take(query.Take);

        if (query.Plate != null)
        {
            bikes = bikes.Where((bike) => bike.Plate.Contains(query.Plate));
        }

        var count = bikes.Count();
        return Ok(new { count, items = bikes });
    }

    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var bike = _context.Bikes.Find(id);
        return bike == null ? NotFound() : Ok(bike);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateBikeDto dto)
    {
        Bike bike =
            new()
            {
                Year = dto.Year,
                Model = dto.Model,
                Plate = dto.Plate
            };

        _context.Bikes.Add(bike);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetOne), new { id = bike.Id }, bike);
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateBikeDto dto)
    {
        var bike = _context.Bikes.Find(id);
        if (bike == null)
        {
            return NotFound();
        }
        if (dto.Plate != null)
        {
            bike.Plate = dto.Plate;
        }
        _context.SaveChanges();
        return Ok(bike);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var bike = _context
            .Bikes.Where(b => b.Id == id)
            .Include(b => b.Rentals.Where(r => r.EndDate > DateTime.Now))
            .FirstOrDefault();

        if (bike == null)
        {
            return NotFound();
        }

        if (bike.Rentals.Count != 0)
        {
            return BadRequest("Bike is already rented");
        }

        _context.Bikes.Remove(bike);
        _context.SaveChanges();
        return NoContent();
    }
}

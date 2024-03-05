using Microsoft.AspNetCore.Mvc;
using Mottu.Data;
using Mottu.Data.Dtos;
using Mottu.Data.Queries;
using Mottu.Models;

namespace Mottu.Controllers;

[ApiController]
[Route("bikes")]
public class BikeController(MottuDbContext context) : Controller
{
    private readonly MottuDbContext _context = context;

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
        var bike = _context.Bikes.Find(id);
        if (bike == null)
        {
            return NotFound();
        }
        _context.Bikes.Remove(bike);
        _context.SaveChanges();
        return NoContent();
    }
}

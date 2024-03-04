using Microsoft.AspNetCore.Mvc;
using Mottu.Data;
using Mottu.Data.Dtos;
using Mottu.Models;

namespace Mottu.Controllers;

[ApiController]
[Route("bikes")]
public class BikeController(MottuDbContext context) : Controller
{
    private readonly MottuDbContext _context = context;

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Bikes.Skip(0).Take(10));
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var bike = _context.Bikes.Find(id);
        return bike == null ? NotFound() : Ok(bike);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateBikeDto dto)
    {
        Bike bike =
            new()
            {
                Year = dto.Year,
                Model = dto.Model,
                Identifier = dto.Identifier,
                Plate = dto.Plate
            };

        _context.Bikes.Add(bike);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = bike.Id }, bike);
    }
}

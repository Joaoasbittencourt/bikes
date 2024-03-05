using Bikes.Data;
using Microsoft.AspNetCore.Mvc;

namespace bikes;

[ApiController]
[Route("riders")]
public class RiderController(BikesDbContext context) : Controller
{
    private readonly BikesDbContext _context = context;

    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var rider = _context.Riders.Find(id);
        return rider == null ? NotFound() : Ok(rider);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateRiderDto dto)
    {
        var rider = new Rider
        {
            Name = dto.Name,
            Cnpj = dto.Cnpj,
            Birthdate = dto.Birthdate,
            CnhNumber = dto.CnhNumber,
            CnhType = dto.CnhType,
            CnhPhotoUrl = dto.CnhPhotoUrl
        };

        _context.Riders.Add(rider);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetOne), new { id = rider.Id }, rider);
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateRiderDto dto)
    {
        var existingRider = _context.Riders.Find(id);
        if (existingRider == null)
        {
            return NotFound();
        }

        if (dto.CnhPhotoUrl != null)
        {
            existingRider.CnhPhotoUrl = dto.CnhPhotoUrl;
        }

        _context.SaveChanges();
        return Ok(existingRider);
    }
}

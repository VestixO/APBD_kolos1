using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingController : ControllerBase
{
    private readonly IBookingRepository _repository;

    public BookingController(IBookingRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBooking(int id)
    {
        var result = await _repository.GetBookingAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] CreateBookingDto dto)
    {
        var error = await _repository.AddBookingAsync(dto);
        if (error != null)
            return BadRequest(new { message = error });

        return StatusCode(201);
    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetBookingDto?> GetBookingAsync(int id)
    {
        var booking = await _context.Bookings
            .Include(b => b.Guest)
            .Include(b => b.Employee)
            .Include(b => b.BookingAttractions)
                .ThenInclude(ba => ba.Attraction)
            .FirstOrDefaultAsync(b => b.BookingId == id);

        if (booking == null) return null;

        return new GetBookingDto
        {
            Date = booking.Date,
            Guest = new GuestDto
            {
                FirstName = booking.Guest.FirstName,
                LastName = booking.Guest.LastName,
                DateOfBirth = booking.Guest.DateOfBirth
            },
            Employee = new EmployeeDto
            {
                FirstName = booking.Employee.FirstName,
                LastName = booking.Employee.LastName,
                EmployeeNumber = booking.Employee.EmployeeNumber
            },
            Attractions = booking.BookingAttractions.Select(ba => new AttractionDto
            {
                Name = ba.Attraction.Name,
                Price = ba.Attraction.Price,
                Amount = ba.Amount
            }).ToList()
        };
    }

    public async Task<string?> AddBookingAsync(CreateBookingDto dto)
    {
        if (await _context.Bookings.AnyAsync(b => b.BookingId == dto.BookingId))
            return "Booking already exists";

        var guest = await _context.Guests.FindAsync(dto.GuestId);
        if (guest == null) return "Guest not found";

        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == dto.EmployeeNumber);
        if (employee == null) return "Employee not found";

        var booking = new Booking
        {
            BookingId = dto.BookingId,
            GuestId = guest.GuestId,
            EmployeeId = employee.EmployeeId,
            Date = DateTime.Now,
            BookingAttractions = new List<BookingAttraction>()
        };

        foreach (var attrDto in dto.Attractions)
        {
            var attraction = await _context.Attractions.FirstOrDefaultAsync(a => a.Name == attrDto.Name);
            if (attraction == null) return $"Attraction '{attrDto.Name}' not found";

            booking.BookingAttractions.Add(new BookingAttraction
            {
                BookingId = booking.BookingId,
                AttractionId = attraction.AttractionId,
                Amount = attrDto.Amount
            });
        }

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return null;
    }
}

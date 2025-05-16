using WebApplication1.Dtos;

namespace WebApplication1.Repositories;

public interface IBookingRepository
{
    Task<GetBookingDto?> GetBookingAsync(int id);
    Task<string?> AddBookingAsync(CreateBookingDto dto);
}
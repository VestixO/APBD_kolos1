namespace WebApplication1.Models;
public class BookingAttraction
{
    public int BookingId { get; set; }
    public int AttractionId { get; set; }
    public int Amount { get; set; }

    public Booking Booking { get; set; }
    public Attraction Attraction { get; set; }
}
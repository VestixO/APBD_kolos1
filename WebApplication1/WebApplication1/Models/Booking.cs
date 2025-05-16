namespace WebApplication1.Models;
public class Booking
{
    public int BookingId { get; set; }
    public int GuestId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; }

    public Guest Guest { get; set; }
    public Employee Employee { get; set; }
    public ICollection<BookingAttraction> BookingAttractions { get; set; }
}

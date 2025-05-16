namespace WebApplication1.Models;
public class Guest
{
    public int GuestId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}
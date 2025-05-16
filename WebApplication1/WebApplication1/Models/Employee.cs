namespace WebApplication1.Models;
public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeNumber { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}
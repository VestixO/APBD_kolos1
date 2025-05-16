namespace WebApplication1.Dtos;

public class GetBookingDto
{
    public DateTime Date { get; set; }
    public GuestDto Guest { get; set; }
    public EmployeeDto Employee { get; set; }
    public List<AttractionDto> Attractions { get; set; }
}

public class GuestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}

public class EmployeeDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeNumber { get; set; }
}

public class AttractionDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}
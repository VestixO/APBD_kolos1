using System.ComponentModel.DataAnnotations;
public class CreateBookingDto
{
    [Required]
    public int BookingId { get; set; }
    [Required]
    public int GuestId { get; set; }
    [Required]
    public string EmployeeNumber { get; set; }
    [MinLength(1, ErrorMessage = "At least one attraction is required")]
    public List<CreateAttractionDto> Attractions { get; set; }
}
public class CreateAttractionDto
{
    [Required]
    public string Name { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public int Amount { get; set; }
}
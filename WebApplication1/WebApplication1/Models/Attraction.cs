namespace WebApplication1.Models;
public class Attraction
{
    public int AttractionId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public ICollection<BookingAttraction> BookingAttractions { get; set; }
}
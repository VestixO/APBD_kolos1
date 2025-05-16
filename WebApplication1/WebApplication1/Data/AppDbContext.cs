using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Attraction> Attractions { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<BookingAttraction> BookingAttractions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingAttraction>()
            .HasKey(ba => new { ba.BookingId, ba.AttractionId });
        modelBuilder.Entity<BookingAttraction>()
            .HasOne(ba => ba.Booking)
            .WithMany(b => b.BookingAttractions)
            .HasForeignKey(ba => ba.BookingId);
        modelBuilder.Entity<BookingAttraction>()
            .HasOne(ba => ba.Attraction)
            .WithMany(a => a.BookingAttractions)
            .HasForeignKey(ba => ba.AttractionId);
    }

    public async Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}



public abstract class DbContextOptions<T>
{
}
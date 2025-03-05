using Microsoft.EntityFrameworkCore;
using HotelMS;
public class HotelDbContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Use a relative path or configuration file for the database path
        optionsBuilder.UseSqlite("Data Source=HotelManagement.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entity relationships and constraints here (if needed)
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Room)
            .WithMany()
            .HasForeignKey(b => b.RoomId);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Guest)
            .WithMany()
            .HasForeignKey(b => b.GuestId);
        modelBuilder.Entity<Guest>()
            .HasKey(g => g.GuestId); // Set GuestId as the primary key
    }
}
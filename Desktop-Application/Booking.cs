public class Booking
{
    public int BookingId { get; set; }
    public int RoomId { get; set; }
    public int GuestId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal TotalCost { get; set; }

    public Room? Room { get; set; }
    public Guest? Guest { get; set; }
}

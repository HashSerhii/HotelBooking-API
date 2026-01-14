namespace HotelBooking.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public string UserId { get; set; } = string.Empty;
    public User? User { get; set; }
    
    public int RoomId { get; set; }
    public Room? Room { get; set; }
}
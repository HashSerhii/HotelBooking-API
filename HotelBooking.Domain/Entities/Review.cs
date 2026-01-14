namespace HotelBooking.Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public string UserId { get; set; }
    public User? User { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
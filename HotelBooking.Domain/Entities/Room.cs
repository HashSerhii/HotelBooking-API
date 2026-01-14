namespace HotelBooking.Domain.Entities;

public class Room
{
    public int Id { get; set; }
    
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;
    
    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
}
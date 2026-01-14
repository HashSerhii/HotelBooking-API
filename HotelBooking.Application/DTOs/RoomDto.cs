namespace HotelBooking.Application.DTOs;

public class RoomDto
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
}
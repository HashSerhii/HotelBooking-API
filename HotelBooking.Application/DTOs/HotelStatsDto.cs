namespace HotelBooking.Application.DTOs;

public class HotelStatsDto
{
    public string HotelName { get; set; } = string.Empty;
    public int TotalBookings { get; set; }
    public decimal TotalRevenue { get; set; }
}
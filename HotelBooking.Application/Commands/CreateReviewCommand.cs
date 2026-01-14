using System.Text.Json.Serialization;

namespace HotelBooking.Application.Commands;

public sealed record CreateReviewCommand(
    int HotelId,
    int Rating,
    string Comment
)
{
    [JsonIgnore] 
    public string? UserId { get; set; } 
}
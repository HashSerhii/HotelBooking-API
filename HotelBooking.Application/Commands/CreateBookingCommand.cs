namespace HotelBooking.Application.Commands;

public sealed record CreateBookingCommand(
    int RoomId,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    string UserId 
);
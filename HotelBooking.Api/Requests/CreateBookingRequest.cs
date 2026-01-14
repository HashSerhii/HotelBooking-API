namespace HotelBooking.Api.Requests;

public record CreateBookingRequest(
    int RoomId, 
    DateTime CheckInDate, 
    DateTime CheckOutDate
);
using HotelBooking.Application.Mediator.Interfaces;

namespace HotelBooking.Application.Commands;

public sealed record CreateRoomCommand(
    int HotelId, 
    string Number,  
    string Type, 
    decimal Price,
    int Capacity
);
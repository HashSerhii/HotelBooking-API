using HotelBooking.Application.Mediator.Interfaces;

namespace HotelBooking.Application.Commands;

public sealed record CreateHotelCommand(
    string Name,
    string Address, 
    string Description
);
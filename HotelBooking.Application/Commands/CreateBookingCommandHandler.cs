using HotelBooking.Application.Mediator.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;

namespace HotelBooking.Application.Commands;

public class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand, int>
{
    private readonly IGenericRepository<Booking> _bookingRepository;
    private readonly IGenericRepository<Room> _roomRepository;

    public CreateBookingCommandHandler(
        IGenericRepository<Booking> bookingRepository, 
        IGenericRepository<Room> roomRepository)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
    }

    public async Task<int> ExecuteAsync(CreateBookingCommand command, CancellationToken ct)
    {
        var room = await _roomRepository.GetByIdAsync(command.RoomId);
        if (room == null)
        {
            throw new Exception("Number not found");
        }
        
        if (command.CheckInDate >= command.CheckOutDate)
        {
            throw new Exception("Check-out date may be later than check-in date");
        }
        
        
        var existingBookings = await _bookingRepository.GetAllAsync(b => 
            b.RoomId == command.RoomId &&
            b.CheckInDate < command.CheckOutDate &&
            b.CheckOutDate > command.CheckInDate
        );

        if (existingBookings.Any())
        {
            throw new Exception("Check-out date may be later than check-in date");
        }
        
        var days = (command.CheckOutDate - command.CheckInDate).Days;
        if (days == 0) days = 1;
        var totalPrice = room.Price * days;
        
        var booking = new Booking
        {
            RoomId = command.RoomId,
            UserId = command.UserId,
            CheckInDate = command.CheckInDate,
            CheckOutDate = command.CheckOutDate,
            TotalPrice = totalPrice
        };

        await _bookingRepository.AddAsync(booking);

        return booking.Id;
    }
}
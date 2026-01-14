using HotelBooking.Application.Mediator.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;

namespace HotelBooking.Application.Commands;

public class CreateRoomCommandHandler : ICommandHandler<CreateRoomCommand, int>
{
    private readonly IGenericRepository<Room> _repository;

    public CreateRoomCommandHandler(IGenericRepository<Room> repository)
    {
        _repository = repository;
    }

    public async Task<int> ExecuteAsync(CreateRoomCommand command, CancellationToken cancellationToken)
    {
        var room = new Room
        {
            HotelId = command.HotelId,
            Number = command.Number,
            Type = command.Type,
            Price = command.Price,
            Capacity = command.Capacity,
            IsAvailable = true
        };

        await _repository.AddAsync(room);

        return room.Id;
    }
}
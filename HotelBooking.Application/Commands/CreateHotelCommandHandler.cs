using HotelBooking.Application.Mediator.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;

namespace HotelBooking.Application.Commands;

public class CreateHotelCommandHandler : ICommandHandler<CreateHotelCommand, int>
{
    private readonly IGenericRepository<Hotel> _repository;
    
    public CreateHotelCommandHandler(IGenericRepository<Hotel> repository)
    {
        _repository = repository;
    }
    
    public async Task<int> ExecuteAsync(CreateHotelCommand command, CancellationToken cancellationToken)
    {
        var hotel = new Hotel
        {
            Name = command.Name,
            Address = command.Address,
            Description = command.Description
        };
        
        await _repository.AddAsync(hotel);
        
        return hotel.Id;
    }
}
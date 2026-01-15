using HotelBooking.Application.DTOs;
using HotelBooking.Application.Mediator.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;

namespace HotelBooking.Application.Queries;

public class GetHotelsQueryHandler : IQueryHandler<GetHotelsQuery, List<HotelDto>>
{
    private readonly IGenericRepository<Hotel> _repository;

    public GetHotelsQueryHandler(IGenericRepository<Hotel> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<HotelDto>> ExecuteAsync(GetHotelsQuery query, CancellationToken ct)
    {
        System.Linq.Expressions.Expression<Func<Hotel, bool>>? filter = 
            string.IsNullOrWhiteSpace(query.SearchTerm) 
                ? null 
                : h => h.Name.Contains(query.SearchTerm) || h.Address.Contains(query.SearchTerm);

        var hotels = await _repository.GetAllAsync(filter, h => h.Rooms);
        
        var dtos = hotels.Select(h => new HotelDto
        {
            Id = h.Id,
            Name = h.Name,
            Address = h.Address,
            Description = h.Description,
            Rooms = h.Rooms.Select(r => new RoomDto
            {
                Id = r.Id,
                Number = r.Number,
                Type = r.Type,
                Price = r.Price,
                Capacity = r.Capacity,
                IsAvailable = r.IsAvailable
            }).ToList()
        }).ToList();

        return dtos;
    }
}
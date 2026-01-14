using HotelBooking.Application.DTOs;
using HotelBooking.Application.Mediator.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;

namespace HotelBooking.Application.Queries;

public class GetMyBookingsQueryHandler : IQueryHandler<GetMyBookingsQuery,List<BookingDto>>
{
    private readonly IGenericRepository<Booking> _repository;

    public GetMyBookingsQueryHandler(IGenericRepository<Booking> repository)
    {
        _repository = repository;
    }

    public async Task<List<BookingDto>> ExecuteAsync(GetMyBookingsQuery query, CancellationToken cancellationToken)
    {
        var bookings = await _repository.GetAllAsync(
            b => b.UserId == query.UserId,
            b => b.Room
        );
        
        return bookings.Select(b=> new BookingDto
            {
                Id = b.Id,
                RoomNumber = b.Room?.Number ?? "Unknown",
                RoomType = b.Room?.Type ?? "Standard",
                CheckInDate = b.CheckInDate,
                CheckOutDate = b.CheckOutDate,
                TotalPrice = b.TotalPrice
            }).ToList();
    }
}
using HotelBooking.Application.Mediator.Interfaces;
using HotelBooking.Application.Commands;
using Microsoft.Extensions.DependencyInjection;
using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Services;
using HotelBooking.Application.Queries;
using HotelBooking.Application.DTOs;

namespace HotelBooking.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator.Mediator>();
        services.AddScoped<IUserService, UserService>();
        
        services.AddTransient<ICommandHandler<CreateHotelCommand, int>, CreateHotelCommandHandler>();
        services.AddTransient<ICommandHandler<CreateRoomCommand, int>, CreateRoomCommandHandler>();
        services.AddTransient<ICommandHandler<CreateBookingCommand, int>, CreateBookingCommandHandler>();
        services.AddTransient<IQueryHandler<GetMyBookingsQuery, List<BookingDto>>, GetMyBookingsQueryHandler>();
        services.AddTransient<IQueryHandler<GetHotelStatsQuery, List<HotelStatsDto>>, GetHotelStatsQueryHandler>();
        services.AddTransient<ICommandHandler<CreateReviewCommand, int>, CreateReviewCommandHandler>();
        
        return services;
    }
}
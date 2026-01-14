using System.Security.Claims;
using HotelBooking.Api.Endpoints;
using HotelBooking.Application.Commands;
using HotelBooking.Application.Mediator.Interfaces;
using HotelBooking.Application.Queries;
using HotelBooking.Application.DTOs;
using HotelBooking.Api.Requests;

namespace HotelBooking.Api.Endpoints;

public static class BookingEndpoints
{
    public static void MapBookingEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Bookings, CreateBooking)
           .WithTags("Bookings")
           .WithOpenApi()
           .RequireAuthorization();

        app.MapGet($"{ApiRoutes.Bookings}/my", GetMyBookings)
           .WithTags("Bookings")
           .RequireAuthorization();
    }

    private static async Task<IResult> CreateBooking(
        CreateBookingRequest request,
        ClaimsPrincipal user,
        IMediator mediator,
        CancellationToken ct)
    {
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (string.IsNullOrEmpty(userId)) 
        {
            return Results.Unauthorized();
        }
        
        var command = new CreateBookingCommand(
            request.RoomId,
            request.CheckInDate,
            request.CheckOutDate,
            userId
        );

        try 
        {
            var bookingId = await mediator.ExecuteCommand<CreateBookingCommand, int>(command, ct);
            return Results.Ok(bookingId);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> GetMyBookings(
        ClaimsPrincipal user,
        IMediator mediator,
        CancellationToken ct)
    {
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId)) return Results.Unauthorized();

        var query = new GetMyBookingsQuery(userId);
        
        var bookings = await mediator.ExecuteQuery<GetMyBookingsQuery, List<BookingDto>>(query, ct);
        
        return Results.Ok(bookings);
    }
}
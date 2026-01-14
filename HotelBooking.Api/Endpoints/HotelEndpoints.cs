using HotelBooking.Application.Commands;
using HotelBooking.Application.Mediator.Interfaces;
using HotelBooking.Application.Queries;
using HotelBooking.Application.DTOs;

namespace HotelBooking.Api.Endpoints;

public static class HotelEndpoints
{
    public static void MapHotelEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Hotels, CreateHotel)
            .WithTags("Hotels")
            .WithOpenApi()
            .RequireAuthorization(policy => policy.RequireRole("Admin"));
        
        app.MapGet(ApiRoutes.Hotels, GetAllHotels)
            .WithTags("Hotels")
            .WithOpenApi();
        app.MapGet("api/hotels/stats", GetHotelStats)
            .WithTags("Hotels")
            .RequireAuthorization(policy => policy.RequireRole("Admin"));
    }

    private static async Task<IResult> CreateHotel(
        CreateHotelCommand command,
        IMediator mediator,
        CancellationToken ct)
    {
        var hotelId = await mediator.ExecuteCommand<CreateHotelCommand, int>(command, ct);
        
        return Results.Ok(hotelId);
    }
    
    private static async Task<IResult> GetAllHotels(
        IMediator mediator,
        CancellationToken ct)
    {
        var query = new GetHotelsQuery();
        
        var hotels = await mediator.ExecuteQuery<GetHotelsQuery, List<HotelDto>>(query, ct);
        
        return Results.Ok(hotels);
    }
    
    private static async Task<IResult> GetHotelStats(
        IMediator mediator,
        CancellationToken ct)
    {
        var query = new GetHotelStatsQuery();
        
        var stats = await mediator.ExecuteQuery<GetHotelStatsQuery, List<HotelStatsDto>>(query, ct);

        return Results.Ok(stats);
    }
}
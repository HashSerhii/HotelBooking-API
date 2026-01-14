using HotelBooking.Application.Commands;
using HotelBooking.Application.Mediator.Interfaces;

namespace HotelBooking.Api.Endpoints;

public static class RoomEndpoints
{
    public static void MapRoomEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Rooms, CreateRoom)
            .WithTags("Rooms")
            .WithOpenApi()
            .RequireAuthorization(policy => policy.RequireRole("Admin"));
    }

    private static async Task<IResult> CreateRoom(
        CreateRoomCommand command,
        IMediator mediator,
        CancellationToken ct)
    {
        var roomId = await mediator.ExecuteCommand<CreateRoomCommand, int>(command, ct);
        return Results.Ok(roomId);
    }
}
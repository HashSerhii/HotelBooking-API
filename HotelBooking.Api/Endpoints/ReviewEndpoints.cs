using System.Security.Claims;
using HotelBooking.Application.Commands;
using HotelBooking.Application.Mediator.Interfaces;
using Microsoft.AspNetCore.Mvc; // Для [FromBody], хоча в Minimal API він часто не обов'язковий

namespace HotelBooking.Api.Endpoints;

public static class ReviewEndpoints
{
    public static void MapReviewEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Review, CreateReview)
            .WithTags("Reviews")
            .WithOpenApi()
            .RequireAuthorization();
    }

    private static async Task<IResult> CreateReview(
        CreateReviewCommand command,
        IMediator mediator,
        ClaimsPrincipal user,
        CancellationToken ct)
    {
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            return Results.Unauthorized();
        }
        
        command.UserId = userId;
        
        var reviewId = await mediator.ExecuteCommand<CreateReviewCommand, int>(command, ct);
        
        return Results.Ok(reviewId);
    }
}
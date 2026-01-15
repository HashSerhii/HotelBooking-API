using HotelBooking.Application.DTOs;
using HotelBooking.Application.Interfaces;

namespace HotelBooking.Api.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Register, async (RegisterDto dto, IUserService userService) =>
            {
                var result = await userService.RegisterAsync(dto);
            
                return result.Succeeded
                    ? Results.Ok("Registration was successful")
                    : Results.BadRequest(result.Errors);
            })
            .WithTags("Users")
            .WithOpenApi();
        
        app.MapPost(ApiRoutes.Login, async (LoginDto dto, IUserService userService) =>
            {
                var authResult = await userService.LoginAsync(dto);
            
                return authResult is not null
                    ? Results.Ok(authResult)
                    : Results.BadRequest("Incorrect email or password");
            })
            .WithTags("Users")
            .WithOpenApi();

        return app;
    }
}
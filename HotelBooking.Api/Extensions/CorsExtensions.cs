namespace HotelBooking.Api.Extensions;

public static class CorsExtensions
{
    private const string PolicyName = "AllowAll";
    
    public static IServiceCollection AddHotelCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(PolicyName, policy =>
            {
                policy.AllowAnyOrigin() 
                    .AllowAnyMethod() 
                    .AllowAnyHeader(); 
            });
        });

        return services;
    }
    
    public static IApplicationBuilder UseHotelCors(this IApplicationBuilder app)
    {
        app.UseCors(PolicyName);
        return app;
    }
}
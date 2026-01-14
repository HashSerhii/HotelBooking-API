using HotelBooking.Infrastructure.Persistence;

namespace HotelBooking.Api.Extensions;

public static class AppExtensions
{
    public static async Task SeedDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        
        try
        {
            await DbInitializer.SeedAsync(services);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error seeding database: {ex.Message}");
        }
    }
}
using HotelBooking.Domain.Interfaces;
using HotelBooking.Infrastructure.Persistence;
using HotelBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HotelBooking.Application.Mediator.Interfaces;
using HotelBooking.Application.Mediator;
using HotelBooking.Application.Interfaces;
using HotelBooking.Infrastructure.Authentication;
using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HotelBooking.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddSingleton<IMediator, Mediator>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddJwtAuthentication(configuration);

        return services;
    }
}
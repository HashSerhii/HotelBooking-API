using HotelBooking.Api.Endpoints;
using HotelBooking.Api.Extensions; 
using HotelBooking.Application;
using HotelBooking.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHotelCors();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerWithAuth(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHotelCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapHotelEndpoints();
app.MapUserEndpoints();
app.MapRoomEndpoints();
app.MapBookingEndpoints();
app.MapReviewEndpoints();

await app.SeedDatabaseAsync();

app.Run();
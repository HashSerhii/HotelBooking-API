using Dapper;
using HotelBooking.Application.DTOs;
using HotelBooking.Application.Mediator.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace HotelBooking.Application.Queries;

public class GetHotelStatsQueryHandler : IQueryHandler<GetHotelStatsQuery, List<HotelStatsDto>>
{
    private readonly string _connectionString;

    public GetHotelStatsQueryHandler(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") 
                            ?? throw new Exception("Connection string not found");
    }

    public async Task<List<HotelStatsDto>> ExecuteAsync(GetHotelStatsQuery query, CancellationToken ct)
    { 
        var sql = @"
            SELECT 
                h.Name AS HotelName, 
                COUNT(b.Id) AS TotalBookings, 
                COALESCE(SUM(b.TotalPrice), 0) AS TotalRevenue
            FROM Hotels h
            LEFT JOIN Rooms r ON h.Id = r.HotelId
            LEFT JOIN Bookings b ON r.Id = b.RoomId
            GROUP BY h.Id, h.Name
            ORDER BY TotalRevenue DESC;";

        using (IDbConnection db = new MySqlConnection(_connectionString))
        {
            var stats = await db.QueryAsync<HotelStatsDto>(sql);
            return stats.ToList();
        }
    }
}
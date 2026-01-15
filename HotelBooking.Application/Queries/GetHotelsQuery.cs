using HotelBooking.Application.DTOs;

namespace HotelBooking.Application.Queries;

public record GetHotelsQuery(string? SearchTerm = null);
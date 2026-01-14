using HotelBooking.Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace HotelBooking.Application.Interfaces;

public interface IUserService
{
    Task<IdentityResult> RegisterAsync(RegisterDto dto);
    Task<AuthResponseDto?> LoginAsync(LoginDto dto);
}
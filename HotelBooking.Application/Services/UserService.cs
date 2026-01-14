using HotelBooking.Application.DTOs;
using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HotelBooking.Application.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public UserService(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
    {
        var user = new User
        {
            UserName = dto.Email,
            Email = dto.Email
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "Client");
        }

        return result;
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null) return null;

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        if (!result.Succeeded) return null;

        var roles = await _userManager.GetRolesAsync(user);
        var token = _jwtTokenGenerator.GenerateToken(user, roles);

        return new AuthResponseDto
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddHours(1)
        };
    }
}
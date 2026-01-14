using Microsoft.AspNetCore.Identity;

namespace HotelBooking.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    
    
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
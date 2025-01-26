using Microsoft.AspNetCore.Identity;

namespace MeetingRoomBookingSystem.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Pin { get; set; }
        public string? Department { get; set; }
    }
}

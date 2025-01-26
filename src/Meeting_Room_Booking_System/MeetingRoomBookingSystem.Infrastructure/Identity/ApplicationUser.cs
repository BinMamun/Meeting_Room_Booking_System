using Microsoft.AspNetCore.Identity;

namespace MeetingRoomBookingSystem.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FullName { get; set; }
        public string UserName { get; set; }
        public string? Department { get; set; }
    }
}

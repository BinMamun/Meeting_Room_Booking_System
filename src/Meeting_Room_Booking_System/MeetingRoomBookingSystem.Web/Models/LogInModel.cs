using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace MeetingRoomBookingSystem.Web.Models
{
    public class LogInModel
    {
        [Required]
        public int Pin { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
        public IList<AuthenticationScheme>? ExternalLogins { get; set; }

    }
}

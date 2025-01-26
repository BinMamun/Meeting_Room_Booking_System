using System.ComponentModel.DataAnnotations;
using MeetingRoomBookingSystem.Domain;

namespace MeetingRoomBookingSystem.Web.Areas.Admin.Models.MeetingRoomModels
{
    public class MeetingRoomCreateModel : DataTables
    {
        [Required, Display(Name = "Meeting Room Name")]
        public string MeetingRoomTitle { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? Location { get; set; }

        [Required]
        public int Capacity { get; set; }
        public string? Facilities { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        [Required, Display(Name = "Available Day")]
        public DateTime? Available { get; set; }
    }
}

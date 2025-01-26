
namespace MeetingRoomBookingSystem.Domain.Entities
{
    public class Booking : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string MeetingTitle { get; set; }
        public DateTime Meetingtime { get; set; }
        public string? MeetingPurpose { get; set; }
        public Guid MeetingId { get; set; }
        public MeetingRoom MeetingRoom { get; set; }
        
    }
}

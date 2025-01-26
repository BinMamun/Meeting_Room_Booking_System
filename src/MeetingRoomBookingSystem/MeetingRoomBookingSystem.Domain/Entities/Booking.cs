
namespace MeetingRoomBookingSystem.Domain.Entities
{
    public class Booking : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string MeetingTitle { get; set; }
        public DateTime Meetingtime { get; set; }
        public string? MeetingPurpose { get; set; }
        //public TimeSpan StartTime { get; set; }
        //public TimeSpan? EndTime { get; set; }
        public Guid MeetingRoomId { get; set; }
        public MeetingRoom MeetingRoom { get; set; }
        
    }
}


namespace MeetingRoomBookingSystem.Domain.Entities
{
    public class MeetingRoom : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string MeetingRoomTitle { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public string? Image { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
        public string? Facilities { get; set; }
        public bool IsActive { get; set; }
        public DateOnly? Available { get; set; }

    }
}


using MeetingRoomBookingSystem.Domain.Entities;

namespace MeetingRoomBookingSystem.Domain.ServiceContracts
{
    public interface IMeetingRoomManagementService
    {
        Task CreateMeetingRoomAsync(MeetingRoom meetingRoom);
    }
}

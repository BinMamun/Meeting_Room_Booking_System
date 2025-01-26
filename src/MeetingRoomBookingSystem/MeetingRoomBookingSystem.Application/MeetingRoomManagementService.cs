
using MeetingRoomBookingSystem.Domain;
using MeetingRoomBookingSystem.Domain.Entities;
using MeetingRoomBookingSystem.Domain.ServiceContracts;

namespace MeetingRoomBookingSystem.Application
{
    public class MeetingRoomManagementService(IApplicationUnitOfWork applicationUnitOfWork) : IMeetingRoomManagementService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork = applicationUnitOfWork;

        public async Task CreateMeetingRoomAsync(MeetingRoom meetingRoom)
        {
            if (meetingRoom == null)
                throw new ArgumentNullException(nameof(meetingRoom), "Meeting room object cannot be null.");

            var existingRoom = _applicationUnitOfWork.MeetingRoomRepository.IsTitleDuplicateAsync(meetingRoom.MeetingRoomTitle);

            if (existingRoom != null)
                throw new InvalidOperationException("A meeting room with the same name and location already exists.");

            await _applicationUnitOfWork.MeetingRoomRepository.AddAsync(meetingRoom);
            await _applicationUnitOfWork.SaveAsync();

        }
    }
}


using MeetingRoomBookingSystem.Domain.Entities;

namespace MeetingRoomBookingSystem.Domain.RepositoryContracts
{
    public interface IMeetingRoomRepository : IRepositoryBase<MeetingRoom, Guid>
    {
        Task<bool> IsTitleDuplicateAsync(string title, Guid? id = null);
    }
}

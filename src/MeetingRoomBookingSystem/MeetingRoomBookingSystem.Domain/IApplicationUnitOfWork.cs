
using MeetingRoomBookingSystem.Domain.RepositoryContracts;

namespace MeetingRoomBookingSystem.Domain
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        public IMeetingRoomRepository MeetingRoomRepository {get;}
        public IBookingRepository BookingRepository { get; }
    }
}

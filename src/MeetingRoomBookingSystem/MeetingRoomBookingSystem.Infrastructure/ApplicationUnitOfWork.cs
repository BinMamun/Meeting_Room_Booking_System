
using MeetingRoomBookingSystem.Domain;
using MeetingRoomBookingSystem.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBookingSystem.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IMeetingRoomRepository MeetingRoomRepository { get; private set; }
        public IBookingRepository BookingRepository { get; private set; }
        public ApplicationUnitOfWork(
            ApplicationDbContext dbContext,
            IMeetingRoomRepository meetingRoomRepository,
            IBookingRepository bookingRepository
            ) : base(dbContext)
        {
            MeetingRoomRepository = meetingRoomRepository;
            BookingRepository = bookingRepository;
        }
    }
}

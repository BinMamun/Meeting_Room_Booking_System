
using MeetingRoomBookingSystem.Domain.Entities;
using MeetingRoomBookingSystem.Domain.RepositoryContracts;

namespace MeetingRoomBookingSystem.Infrastructure.Repositories
{
    public class BookingRepository : Repository<Booking, Guid>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context) :base(context) { }
    }
}

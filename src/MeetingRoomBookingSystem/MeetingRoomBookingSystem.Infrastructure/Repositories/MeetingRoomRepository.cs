
using MeetingRoomBookingSystem.Domain.Entities;
using MeetingRoomBookingSystem.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBookingSystem.Infrastructure.Repositories
{
    public class MeetingRoomRepository : Repository<MeetingRoom, Guid>, IMeetingRoomRepository
    {
        public MeetingRoomRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}


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

        public async Task<bool> IsTitleDuplicateAsync(string title, Guid? id = null)
        {
            if (id.HasValue)
            {
                return await GetCountAsync(x => !x.Id.Equals(id.Value) && x.MeetingRoomTitle.Equals(title)) > 0;
            }
            else
            {
                return await GetCountAsync(x => x.MeetingRoomTitle.Equals(title)) > 0;
            }
        }
    }
}

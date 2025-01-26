
using MeetingRoomBookingSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBookingSystem.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ApplicationUnitOfWork(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

using Autofac;
using MeetingRoomBookingSystem.Application;
using MeetingRoomBookingSystem.Domain;
using MeetingRoomBookingSystem.Domain.Entities;
using MeetingRoomBookingSystem.Domain.RepositoryContracts;
using MeetingRoomBookingSystem.Domain.ServiceContracts;
using MeetingRoomBookingSystem.Infrastructure;
using MeetingRoomBookingSystem.Infrastructure.Repositories;

namespace MeetingRoomBookingSystem.Web
{
    public class WebModule(string connectionString, string migrationAssembly) : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", connectionString)
                .WithParameter("migrationAssembly", migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>()
                .As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MeetingRoomManagementService>()
                .As<IMeetingRoomManagementService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MeetingRoomRepository>()
                .As<IMeetingRoomRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookingRepository>()
                .As<IBookingRepository>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}

using Autofac;
using MeetingRoomBookingSystem.Infrastructure;

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

            base.Load(builder);
        }
    }
}

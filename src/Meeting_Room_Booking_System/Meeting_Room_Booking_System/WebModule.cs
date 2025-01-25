using Autofac;

namespace MeetingRoomBookingSystem.Web
{
    public class WebModule(string connectionString, string migrationAssembly) : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}

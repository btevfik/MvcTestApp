using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(MvcAppTest2.Hubs.Startup))]
namespace MvcAppTest2.Hubs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}
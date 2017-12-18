using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SantaClaus.Startup))]
namespace SantaClaus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

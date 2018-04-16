using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(farmers_land.Startup))]
namespace farmers_land
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

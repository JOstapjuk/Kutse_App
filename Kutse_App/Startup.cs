using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kutse_App.Startup))]
namespace Kutse_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

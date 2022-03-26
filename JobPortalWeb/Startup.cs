using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobPortalWeb.Startup))]
namespace JobPortalWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

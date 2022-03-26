using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobPortal.Admin.Startup))]
namespace JobPortal.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

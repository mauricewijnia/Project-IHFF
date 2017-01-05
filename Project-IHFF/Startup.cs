using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_IHFF.Startup))]
namespace Project_IHFF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
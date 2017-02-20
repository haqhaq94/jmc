using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InstituteMVC.Startup))]
namespace InstituteMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

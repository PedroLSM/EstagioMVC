using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EstagioMVC.Startup))]
namespace EstagioMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

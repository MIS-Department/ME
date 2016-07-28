using Microsoft.Owin;
using Owin;
using Shared.Web.Util;
using SimpleInjector;

[assembly: OwinStartup(typeof(Shared.Web.Startup))]
namespace Shared.Web
{
    public partial class Startup
    {
        public Container Container = null;
        public void Configuration(IAppBuilder app)
        {
            Container = new Container();
            app.UseOwinContextInjector(Container);
            ConfigureAuth(app);
        }
    }
}

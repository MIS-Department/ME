using Microsoft.Owin;
using Owin;
using Shared.Api.Util;
using SimpleInjector;

[assembly: OwinStartup(typeof(Shared.Api.Startup))]

namespace Shared.Api
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

using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace Shared.Api.Util
{
    public static class OwinConfig
    {
        public static void UseOwinContextInjector(this IAppBuilder app, Container container)
        {
            app.Use(async (context, next) =>
            {
                using (container.BeginExecutionContextScope())
                {
                    await next.Invoke();
                }
            });
        }
    }
}
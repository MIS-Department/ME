using System.Web.Http;
using Shared.Api;
using Shared.DataLayer.Interfaces;
using Shared.DataLayer.Interfaces.IRepositories;
using Shared.DataLayer.Repositories;
using Shared.DataLayer.Util;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorWebApiInitializer), "Initialize")]

namespace Shared.Api
{
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<ICalculatedTimeRepository, CalculatedTimeRepository>(Lifestyle.Singleton);
            container.Register<IDailyTimeRecordRepository, DailyTimeRecordRepository>(Lifestyle.Singleton);
            container.Register<IEmployeeScheduleRepository, EmployeeScheduleRepository>(Lifestyle.Singleton);
            container.Register<IScheduleRepository, ScheduleRepository>(Lifestyle.Singleton);
            container.Register<ITemplateRepository, TemplateRepository>(Lifestyle.Singleton);
            container.Register<IEmployeeRepository, EmployeeRepository>(Lifestyle.Transient);
            container.Register<IDapperContext, DapperContext>(Lifestyle.Singleton);
        }
    }
}
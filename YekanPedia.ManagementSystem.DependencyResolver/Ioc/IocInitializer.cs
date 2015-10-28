namespace YekanPedia.ManagementSystem.DependencyResolver
{
    using StructureMap;
    using StructureMap.Web.Pipeline;
    using System;
    using Data.Conext;
    using InfraStructure;
    using Service.Implement;
    using Service.Interfaces;

    public class IocInitializer
    {
        public static IContainer Container;
        public static void Initialize()
        {
            Container = new Container(x =>
            {
                x.For<IUnitOfWork>().Use(() => new ManagementSystemDbContext()).LifecycleIs<HttpContextLifecycle>();
                x.For<IActionResult>().Use<ActionResult>();
                x.For<IUserService>().Use<UserService>();
            });
        }
        public static object GetInstance(Type pluginType)
        {
            return Container.GetInstance(pluginType);
        }
        public static TPluginType GetInstance<TPluginType>()
        {
            return Container.GetInstance<TPluginType>();
        }
        public static void HttpContextDisposeAndClearAll()
        {
            HttpContextLifecycle.DisposeAndClearAll();
        }
    }
}

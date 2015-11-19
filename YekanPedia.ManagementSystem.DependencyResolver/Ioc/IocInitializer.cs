namespace YekanPedia.ManagementSystem.DependencyResolver
{
    using StructureMap;
    using StructureMap.Web.Pipeline;
    using System;
    using Data.Conext;
    using InfraStructure;
    using Service.Implement;
    using Service.Interfaces;
    using ExternalService.implement;
    using ExternalService.Interfaces;

    public class IocInitializer
    {
        public static IContainer Container;
        public static void Initialize()
        {
            Container = new Container(x =>
            {
                x.For<IUnitOfWork>().Use(() => new ManagementSystemDbContext()).LifecycleIs<HttpContextLifecycle>();
                x.For<IActionResults>().Use<ActionResults>();
                x.For<IUserService>().Use<UserService>();
                x.For<ITaskService>().Use<TaskService>();
                x.For<IClassTypeService>().Use<ClassTypeService>();
                x.For<ICourseService>().Use<CourseService>();
                x.For<IClassService>().Use<ClassService>();
                x.For<Lazy<IClassService>>().Use(c => new Lazy<IClassService>(c.GetInstance<ClassService>));


                x.For<IClassTimeService>().Use<ClassTimeService>();
                x.For<ISessionService>().Use<SessionService>();
                x.For<ISessionMaterialService>().Use<SessionMaterialService>();
                x.For<IUserInClassService>().Use<UserInClassService>();
                x.For<IFeedbackService>().Use<FeedbackService>();
                x.For<INotificationSettingService>().Use<NotificationSettingService>();
                x.For<INotificationService>().Use<NotificationService>();
                x.For<Lazy<INotificationService>>().Use(c => new Lazy<INotificationService>(c.GetInstance<NotificationService>));


                x.For<IMessagingGatewayAdapter>().Use<MessagingGatewayAdapter>();
                x.For<IFilesProxyAdapter>().Use<FilesProxyAdapter>();
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

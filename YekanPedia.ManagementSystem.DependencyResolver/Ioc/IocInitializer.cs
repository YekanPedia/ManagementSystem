namespace YekanPedia.ManagementSystem.DependencyResolver
{
    using StructureMap;
    using StructureMap.Web.Pipeline;
    using System;
    using Data.Context;
    using InfraStructure;
    using Service.Implement;
    using Service.Interfaces;
    using ExternalService.implement;
    using ExternalService.Interfaces;
    using InfraStructure.Caching;
    using YekanPedia.ManagementSystem.Scheduler;
    using InfraStructure.Extension.Authentication;

    public class IocInitializer
    {
        public static IContainer Container;
        public static void Initialize()
        {
            Container = new Container(x =>
            {
                x.For<IStatisticsServicce>().Use<StatisticsServicce>();
                x.For<IStaticFilesService>().Use<StaticFilesService>();
                #region Overview
                x.For<IEducationService>().Use<EducationService>();
                x.For<Lazy<IEducationService>>().Use(c => new Lazy<IEducationService>(c.GetInstance<EducationService>));

                x.For<ISkillsService>().Use<SkillsService>();
                x.For<Lazy<ISkillsService>>().Use(c => new Lazy<ISkillsService>(c.GetInstance<SkillsService>));

                x.For<IWorkService>().Use<WorkService>();
                x.For<Lazy<IWorkService>>().Use(c => new Lazy<IWorkService>(c.GetInstance<WorkService>));

                #endregion

                #region IELTS
                x.For<IIeltsMaterialService>().Use<IeltsMaterialService>();
                x.For<ITopicService>().Use<TopicService>();
                #endregion

                #region Setting
                x.For<IYearEventsService>().Use<YearEventsService>();
                x.For<Lazy<IYearEventsService>>().Use(c => new Lazy<IYearEventsService>(c.GetInstance<YearEventsService>));

                x.For<ISettingService>().Use<SettingService>();
                x.For<Lazy<ISettingService>>().Use(c => new Lazy<ISettingService>(c.GetInstance<SettingService>));

                #endregion

                x.For<IAboutUsService>().Use<AboutUsService>();

                x.For<ISchedulerObserver>().Use<SchedulerObserver>().Singleton();

                x.For<Lazy<ICacheProvider>>().Use(c => new Lazy<ICacheProvider>(c.GetInstance<HttpRuntimeCache>));
                x.For<ICacheProvider>().Use<HttpRuntimeCache>();

                x.For<IUnitOfWork>().Use(() => new ManagementSystemDbContext()).LifecycleIs<HybridLifecycle>();
                x.For<IActionResults>().Use<ActionResults>();
                x.For<IUserService>().Use<UserService>();

                x.For<Lazy<ITaskService>>().Use(c => new Lazy<ITaskService>(c.GetInstance<TaskService>));
                x.For<ITaskService>().Use<TaskService>();

                x.For<IBookService>().Use<BookService>();
                x.For<IExamTypeService>().Use<ExamTypeService>();

                x.For<IClassTypeService>().Use<ClassTypeService>();
                x.For<ICourseService>().Use<CourseService>();
                x.For<IClassService>().Use<ClassService>();
                x.For<Lazy<IClassService>>().Use(c => new Lazy<IClassService>(c.GetInstance<ClassService>));

                x.For<Lazy<IRoleManagementService>>().Use(c => new Lazy<IRoleManagementService>(c.GetInstance<RoleManagementService>));
                x.For<IRoleManagementService>().Use<RoleManagementService>();

                x.For<IClassTimeService>().Use<ClassTimeService>();
                x.For<ISessionService>().Use<SessionService>();
                x.For<ISessionRequestService>().Use<SessionRequestService>();
                x.For<ISessionMaterialService>().Use<SessionMaterialService>();
                x.For<IUserInClassService>().Use<UserInClassService>();
                x.For<IFeedbackService>().Use<FeedbackService>();
                x.For<INotificationSettingService>().Use<NotificationSettingService>();
                x.For<INotificationService>().Use<NotificationService>();
                x.For<Lazy<INotificationService>>().Use(c => new Lazy<INotificationService>(c.GetInstance<NotificationService>));


                x.For<IMessagingGatewayAdapter>().Use<MessagingGatewayAdapter>();
                x.For<IFilesProxyAdapter>().Use<FilesProxyAdapter>();
                x.For<Lazy<IFilesProxyAdapter>>().Use(c => new Lazy<IFilesProxyAdapter>(c.GetInstance<FilesProxyAdapter>));


                x.For<ICurrentUserPrincipal>().Use<CurrentUserPrincipal>();
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

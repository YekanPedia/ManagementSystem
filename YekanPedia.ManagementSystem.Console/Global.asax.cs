namespace YekanPedia.ManagementSystem.Console
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using DependencyResolver;
    using ControllerFactory;
    using System;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MvcHandler.DisableMvcResponseHeader = true;
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            IocInitializer.Initialize();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new IocControllerFactory());

        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            IocInitializer.HttpContextDisposeAndClearAll();
        }
    }
}

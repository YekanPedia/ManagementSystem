namespace YekanPedia.ManagementSystem.Console
{
    using System.Web.Mvc;
    using System.Web.Routing;
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = MVC.OAuth.Name, action = MVC.OAuth.ActionNames.SignIn, id = UrlParameter.Optional }
            );
        }
    }
}

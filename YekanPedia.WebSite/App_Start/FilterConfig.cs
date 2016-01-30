namespace YekanPedia.WebSite
{
    using System.Web.Mvc;
    using ManagementSystem.Console.App_Start.Filters;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandledErrorLoggerFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}

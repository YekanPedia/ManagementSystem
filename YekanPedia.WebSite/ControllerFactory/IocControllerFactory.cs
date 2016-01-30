namespace YekanPedia.WebSite.ControllerFactory
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Controllers;
    using ManagementSystem.DependencyResolver;

    /// <summary>
    /// کنترلر فکتوری تولید شده برای انجام عملیات تزریق وابستگی
    /// </summary>
    public class IocControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// ایجاد کنترلر ارسالی و در یافت یک نمونه از آن با تزریق های انجام شده
        /// </summary>
        /// <param name="requestContext">درخواست کاربر</param>
        /// <param name="controllerType">نوع کنترلر که سیستم مسیریابی آن را پر خواهد کرد</param>
        /// <returns>IController اینترفیس </returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                var url = requestContext.HttpContext.Request.RawUrl;
                requestContext.RouteData.Values["controller"] = MVC.Home.Name;
                requestContext.RouteData.Values["action"] = MVC.Home.ActionNames.Index;
                return IocInitializer.GetInstance(typeof(HomeController)) as Controller;
            }
            return IocInitializer.GetInstance(controllerType) as Controller;
        }
    }
}
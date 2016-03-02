namespace YekanPedia.ManagementSystem.Console
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using DependencyResolver;
    using ControllerFactory;
    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.Script.Serialization;
    using Domain.Entity;
    using Extensions.Authentication;
    using ScheduledTasks;
    using Elmah;

    public class MvcApplication : HttpApplication
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
            ScheduledTasksRepository.Init();
        }
       protected void Application_EndRequest(object sender, EventArgs e)
        {
            IocInitializer.HttpContextDisposeAndClearAll();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("x-frame-option", "DENY");
        }
      
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            try
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    if (authTicket.UserData == "OAuth") return;

                    var serializeModel = serializer.Deserialize<CurrentUserPrincipal>(authTicket.UserData);
                    var user = new CurrentUserPrincipal(authTicket.Name);
                    user.UserId = serializeModel.UserId;
                    user.FullName = serializeModel.FullName;
                    user.Email = serializeModel.Email;
                    user.Picture = serializeModel.Picture;
                    HttpContext.Current.User = user;
                }
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                FormsAuthentication.SignOut();
                HttpCookie oldCookie = new HttpCookie(".ASPXAUTH");
                oldCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(oldCookie);

                HttpCookie ASPNET_SessionId = new HttpCookie("ASP.NET_SessionId");
                ASPNET_SessionId.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(ASPNET_SessionId);
                
                var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                Response.Redirect(urlHelper.Action(MVC.OAuth.ActionNames.SignIn, MVC.OAuth.Name));
            }
        }
        protected void Application_End()
        {
            ScheduledTasksRepository.Dispose();
            ScheduledTasksRepository.WakeUp(AppSettings.WakeUpUrl);
        }
    }
}

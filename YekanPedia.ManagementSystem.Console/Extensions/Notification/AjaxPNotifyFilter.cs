namespace YekanPedia.ManagementSystem.Console
{
    using System.Web.Mvc;
    using System.Linq;
    using Newtonsoft.Json;
    using InfraStructure.Extension;
    public class AjaxPNotifyFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Controller.NotificationController().Current.Count() > 0)
                {
                    filterContext.HttpContext.Response.Cookies["Notification"].Value = JsonConvert.SerializeObject(
                        filterContext
                        .Controller
                        .NotificationController()
                        .Current.Select(X => new
                        {
                            Message = X.Message,
                            NotificationStatus = X.NotificationStatus.GetDescription()
                        }));
                }
            }
        }
    }
}

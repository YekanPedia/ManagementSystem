namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;

    public partial class DashboardController : Controller
    {
        [HttpGet]
        public virtual ActionResult User()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult Admin()
        {
            return View();
        }

        [ChildActionOnly]
        public virtual PartialViewResult Messages()
        {
            return PartialView(MVC.Dashboard.Views.Partial.Message);
        }

        [ChildActionOnly]
        public virtual PartialViewResult Notification()
        {
            return PartialView(MVC.Dashboard.Views.Partial.Notification);
        }

        [ChildActionOnly]
        public virtual PartialViewResult Tasks()
        {
            return PartialView(MVC.Dashboard.Views.Partial.Task);
        }
    }
}
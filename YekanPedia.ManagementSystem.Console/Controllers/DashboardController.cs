namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;

    public partial class DashboardController : Controller
    {
        [HttpGet]
        public virtual new ActionResult User()
        {
            return View();
        }

        public virtual ViewResult NotFound()
        {
            return View(Request.UrlReferrer);
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
    }
}
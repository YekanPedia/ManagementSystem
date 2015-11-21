namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;

    public partial class DashboardController : Controller
    {
        #region Constructure
        readonly IClassService _classService;
        public DashboardController(IClassService classService)
        {
            _classService = classService;
        }
        #endregion
        [HttpGet]
        public virtual new ActionResult User()
        {
            return View(_classService.GetClass());
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

        [HttpGet]
        public virtual ViewResult ManageBaseInformation()
        {
            return View();
        }
    }
}
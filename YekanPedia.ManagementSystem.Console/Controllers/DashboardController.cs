namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using Extensions.Authentication;

    public partial class DashboardController : Controller
    {
        #region Constructure
        readonly IClassService _classService;
        readonly IRoleManagementService _roleManagementService;
        public DashboardController(IClassService classService, IRoleManagementService roleManagementService)
        {
            _classService = classService;
            _roleManagementService = roleManagementService;
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

        [ChildActionOnly]
        public virtual PartialViewResult Menu()
        {
            return PartialView(MVC.Dashboard.Views.Partial._Menu, _roleManagementService.GetAvailableMenu((HttpContext.User as ICurrentUserPrincipal).UserId));
        }

        [HttpGet]
        public virtual ViewResult ManageBaseInformation()
        {
            return View();
        }

    }
}

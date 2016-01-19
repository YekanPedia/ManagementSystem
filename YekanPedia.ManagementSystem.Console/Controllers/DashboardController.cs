namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using Extensions.Authentication;
    using ExternalService.Interfaces;
    using Domain.Poco;

    public partial class DashboardController : Controller
    {
        #region Constructure
        readonly IClassService _classService;
        readonly IRoleManagementService _roleManagementService;
        readonly IFilesProxyAdapter _fileProxyAdapter;
        readonly IStatisticsServicce _statisticsService;
        public DashboardController(IClassService classService,
            IRoleManagementService roleManagementService,
            IFilesProxyAdapter fileProxyAdapter,
            IStatisticsServicce statisticsService)
        {
            _classService = classService;
            _roleManagementService = roleManagementService;
            _fileProxyAdapter = fileProxyAdapter;
            _statisticsService = statisticsService;
        }
        #endregion
        [HttpGet]
        public virtual new ActionResult User()
        {
            return View(_classService.GetClass());
        }

        #region Admin Dashboard
        [HttpGet]
        public virtual ActionResult Admin()
        {
            return View();
        }

        [ChildActionOnly]
        public virtual PartialViewResult DirectorySize()
        {
            return PartialView(MVC.Dashboard.Views.Partial._DirectorySize, _fileProxyAdapter.DirectorySize());
        }
        [ChildActionOnly]
        public virtual PartialViewResult SmsSize()
        {
            return PartialView(MVC.Dashboard.Views.Partial._SmsSize, 150241);
        }
        #region User Statistics

        [ChildActionOnly]
        public virtual PartialViewResult UserStatistics()
        {
            return PartialView(MVC.Dashboard.Views.Partial.Chart._UserStatistics, _statisticsService.GetUserStatistics());
        }
        #endregion
        #endregion
        #region Public
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
        #endregion

        [HttpGet]
        public virtual ViewResult ManageBaseInformation()
        {
            return View();
        }
    }
}

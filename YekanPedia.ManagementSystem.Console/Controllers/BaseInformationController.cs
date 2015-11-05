namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;

    public partial class BaseInformationController : Controller
    {
        #region Constructure
        private readonly ICourseService _courseService;
        private readonly IClassTypeService _classTypeService;
        public BaseInformationController(ICourseService courseService, IClassTypeService classTypeService)
        {
            _classTypeService = classTypeService;
            _courseService = courseService;
        }
        #endregion

        [HttpGet]
        public virtual ViewResult Manage()
        {
            return View();
        }
    }
}
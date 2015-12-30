namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;

    public partial class DownloadController : Controller
    {
        readonly ICourseService _courseService;
        readonly IStaticFilesService _staticFilesService;
        public DownloadController(ICourseService courseService, IStaticFilesService staticFilesService)
        {
            _courseService = courseService;
            _staticFilesService = staticFilesService;
        }

        [HttpGet]
        public virtual ActionResult Files()
        {
            return View(_courseService.GetAllCoursesHasStaticFiles());
        }

        [HttpGet]
        public virtual PartialViewResult GetStaticFiles(int courseId)
        {
            return PartialView(MVC.Download.Views.Partial._StaticFilesBlock, _staticFilesService.GetFiles(courseId));
        }
    }
}
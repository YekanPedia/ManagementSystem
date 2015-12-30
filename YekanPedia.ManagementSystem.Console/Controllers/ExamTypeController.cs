namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;

    public partial class ExamTypeController : Controller
    {
        #region Constructure
        private readonly IExamTypeService _examTypeService;
        public ExamTypeController(IExamTypeService ExamTypeService)
        {
            _examTypeService = ExamTypeService;
        }
        #endregion

        [ChildActionOnly]
        public virtual PartialViewResult GetExamType()
        {
            return PartialView(MVC.ExamType.Views.Partial._ExamType, _examTypeService.GetAllExamType());
        }

        [HttpPost]
        public virtual JsonResult ChangeExamTypeStatus(int id, bool status)
        {
            return Json(_examTypeService.ChangeExamTypeStatus(id, status));
        }
        [HttpPost]
        public virtual JsonResult AddExamType(string text)
        {
            return Json(_examTypeService.AddExamType(text));
        }
    }
}
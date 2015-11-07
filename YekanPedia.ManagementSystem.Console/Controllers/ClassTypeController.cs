namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;

    public partial class ClassTypeController : Controller
    {
        #region Constructure
        private readonly IClassTypeService _classTypeService;
        public ClassTypeController(IClassTypeService classTypeService)
        {
            _classTypeService = classTypeService;
        }
        #endregion

        [ChildActionOnly]
        public virtual PartialViewResult GetClassType()
        {
            return PartialView(MVC.ClassType.Views.Partial._ClassType, _classTypeService.GetAllClassType());
        }

        [HttpPost]
        public virtual JsonResult ChangeClassTypeStatus(int id, bool status)
        {
            return Json(_classTypeService.ChangeClassTypeStatus(id, status));
        }
    }
}
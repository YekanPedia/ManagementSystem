namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Domain.Entity;
    using Service.Interfaces;
    using System.Linq;
    using System;

    public partial class ClassController : Controller
    {
        #region Constructure
        private readonly IUserService _userService;
        private readonly IClassTypeService _classTypeService;
        private readonly ICourseService _courseService;
        private readonly IClassService _classService;
        public ClassController(IClassService classService, IUserService userService, ICourseService courseService, IClassTypeService classTypeService)
        {
            _userService = userService;
            _classTypeService = classTypeService;
            _courseService = courseService;
            _classService = classService;
        }
        #endregion

        [NonAction]
        private void SetDropDownlist()
        {
            #region teacher
            var teacher = _userService.GetTeachers().Result;
            ViewBag.Teachers = teacher.Select(x => new SelectListItem()
            {
                Text = x.FullName.ToString(),
                Value = x.UserId.ToString()
            });
            #endregion
            #region classType
            var classType = _classTypeService.GetClassType();
            ViewBag.ClassTypes = classType.Select(x => new SelectListItem()
            {
                Text = x.Type.ToString(),
                Value = x.ClassTypeId.ToString()
            });
            #endregion
            #region course
            var course = _courseService.GetCourses();
            ViewBag.Courses = course.Select(x => new SelectListItem()
            {
                Text = x.CourseName.ToString(),
                Value = x.CourseId.ToString()
            });
            #endregion
        }

        [ChildActionOnly]
        public virtual PartialViewResult ClassList()
        {
            return PartialView(MVC.Class.Views.Partial._ListClass, _classService.GetClass());
        }
        [ChildActionOnly]
        public virtual PartialViewResult ClassTimeList(Guid classId)
        {
            return PartialView(MVC.Class.Views.Partial._ListClassTime, _classTimeService.GetClassTime(classId));
        }
        #region Add Class
        [HttpGet]
        public virtual ViewResult Add()
        {
            SetDropDownlist();
            return View();
        }

        [HttpPost]
        public virtual ActionResult Add(Class model)
        {
            if (!ModelState.IsValid)
            {
                SetDropDownlist();
                return View(model);
            }
            model.ReBind();
            var result = _classService.AddClass(model);
            if (!result.IsSuccessfull)
            {
                //show error
                SetDropDownlist();
                return View(model);
            }
            return RedirectToAction(MVC.Class.ActionNames.AddTime, MVC.Class.Name, new { classId = result.Result.ToString() });
        }
        #endregion
        #region Add Time
        [HttpGet, Route("Class/AddTime/{classId}")]
        public virtual ViewResult AddTime(Guid classId)
        {
            return View(new ClassTime() { ClassId = classId });
        }

        [HttpPost]
        public virtual ActionResult AddTime(ClassTime model)
        {
            if (!ModelState.IsValid)
                View(model);

            _classTimeService.AddTime(model);
            return RedirectToAction(MVC.Class.ActionNames.AddTime, MVC.Class.Name, new { classId = model.ClassId });
        }
        #endregion
    }
}
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
        readonly IUserService _userService;
        readonly IClassTypeService _classTypeService;
        readonly ICourseService _courseService;
        readonly IClassService _classService;
        readonly IClassTimeService _classTimeService;
        public ClassController(IClassTimeService classTimeService, IClassService classService, IUserService userService, ICourseService courseService, IClassTypeService classTypeService)
        {
            _userService = userService;
            _classTypeService = classTypeService;
            _courseService = courseService;
            _classService = classService;
            _classTimeService = classTimeService;
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
            var classType = _classTypeService.GetValidClassType();
            ViewBag.ClassTypes = classType.Select(x => new SelectListItem()
            {
                Text = x.Type.ToString(),
                Value = x.ClassTypeId.ToString()
            });
            #endregion
            #region course
            var course = _courseService.GetValidCourses();
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
        public virtual ViewResult AddClass()
        {
            SetDropDownlist();
            return View();
        }

        [HttpPost]
        public virtual ActionResult AddClass(Class model)
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
                this.NotificationController().Notify(result.Message, NotificationStatus.Error);
                SetDropDownlist();
                return View(model);
            }
            return RedirectToAction(MVC.Class.ActionNames.AddClassTime, MVC.Class.Name, new { classId = result.Result.ToString() });
        }
        #endregion
        #region Edit Class
        [HttpGet]
        public virtual ViewResult EditClass(Guid classId)
        {
            SetDropDownlist();
            return View(_classService.FindClass(classId));
        }

        [HttpPost]
        public virtual ActionResult EditClass(Class model)
        {
            if (!ModelState.IsValid)
            {
                SetDropDownlist();
                return View(model);
            }
            model.ReBind();
            var result = _classService.EditClass(model);
            if (!result.IsSuccessfull)
            {
                this.NotificationController().Notify(result.Message, NotificationStatus.Error);
                SetDropDownlist();
                return View(model);
            }
            return RedirectToAction(MVC.Class.ActionNames.AddClass, MVC.Class.Name);
        }
        #endregion

        #region Add Class Time
        [HttpGet]
        public virtual ViewResult AddClassTime(Guid classId)
        {
            return View(new ClassTime() { ClassId = classId });
        }

        [HttpPost]
        public virtual ActionResult AddClassTime(ClassTime model)
        {
            if (ModelState.IsValid)
            {
                var result = _classTimeService.AddClassTime(model);
                if (!result.IsSuccessfull)
                    this.NotificationController().Notify(result.Message, NotificationStatus.Error);
            }
            return RedirectToAction(MVC.Class.ActionNames.AddClassTime, MVC.Class.Name, new { classId = model.ClassId });
        }
        #endregion
        #region Edit ClassTime
        [HttpGet]
        public virtual ViewResult EditClassTime(int classTimeId)
        {
            return View(_classTimeService.FindClassTime(classTimeId));
        }

        [HttpPost]
        public virtual ActionResult EditClassTime(ClassTime model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _classTimeService.EditClassTime(model);
            if (!result.IsSuccessfull)
            {
                this.NotificationController().Notify(result.Message, NotificationStatus.Error);
                return View(model);
            }
            return RedirectToAction(MVC.Class.ActionNames.AddClass, MVC.Class.Name);
        }
        #endregion

        #region DeleteClassTime
        [HttpPost]
        public virtual JsonResult DeleteClassTime(int classTimeId)
        {
            return Json(_classTimeService.Delete(classTimeId));
        }
        #endregion

        [ChildActionOnly]
        public virtual PartialViewResult ClassDetails(Guid classId)
        {
            return PartialView(MVC.Class.Views.Partial._ClassDetails, _classService.FindFullClassData(classId));
        }
    }
}
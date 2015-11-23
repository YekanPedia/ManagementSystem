namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using System;

    public partial class CourseController : Controller
    {
        #region Constructure
        readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        #endregion

        [ChildActionOnly]
        public virtual PartialViewResult GetCourse()
        {
            return PartialView(MVC.Course.Views.Partial._Course, _courseService.GetAllCourses());
        }
        [HttpPost]
        public virtual JsonResult ChangeCourseStatus(int id, bool status)
        {
            return Json(_courseService.ChangeCourseStatus(id, status));
        }

        [HttpPost]
        public virtual JsonResult AddCourse(string text)
        {
            return Json(_courseService.AddCourse(text));
        }

        [ChildActionOnly]
        public virtual PartialViewResult UserCourses(Guid userId)
        {
            return PartialView(MVC.Course.Views.Partial._UserCurrents,_courseService.GetUserCourses(userId));
        }
    }
}
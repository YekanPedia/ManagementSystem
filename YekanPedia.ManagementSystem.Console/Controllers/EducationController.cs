namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System;
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;

    public partial class EducationController : Controller
    {
        readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [ChildActionOnly]
        public virtual PartialViewResult GetEducations(Guid userId)
        {
            ViewBag.UserId = userId;
            return PartialView(MVC.Education.Views.Partial._Educations, _educationService.GetEducations(userId));
        }

        [HttpPost]
        public virtual JsonResult AddEducation(Education model)
        {
            return Json(_educationService.Add(model));
        }

        [HttpPost]
        public virtual JsonResult ChangePublicState(int educationId)
        {
            return Json(_educationService.ChangePublicState(educationId));
        }

        [HttpPost]
        public virtual JsonResult Remove(int educationId)
        {
            return Json(_educationService.Remove(educationId));
        }
    }
}
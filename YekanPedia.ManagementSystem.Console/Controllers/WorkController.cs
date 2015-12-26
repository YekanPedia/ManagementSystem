namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System;
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;

    public partial class WorkController : Controller
    {
        readonly IWorkService _workService;
        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        [ChildActionOnly]
        public virtual PartialViewResult GetWorks(Guid userId)
        {
            ViewBag.UserId = userId;
            return PartialView(MVC.Work.Views.Partial._Works, _workService.GetWorks(userId));
        }

        [HttpPost]
        public virtual JsonResult AddWork(Work model)
        {
            return Json(_workService.Add(model));
        }

        [HttpPost]
        public virtual JsonResult ChangePublicState(int workId)
        {
            return Json(_workService.ChangePublicState(workId));
        }

        [HttpPost]
        public virtual JsonResult Remove(int workId)
        {
            return Json(_workService.Remove(workId));
        }
    }
}
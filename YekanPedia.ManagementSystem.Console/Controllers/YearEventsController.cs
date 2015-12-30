namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Domain.Entity;
    using Service.Interfaces;

    public partial class YearEventsController : Controller
    {
        readonly IYearEventsService _yearEventsService;
        public YearEventsController(IYearEventsService yearEventsService)
        {
            _yearEventsService = yearEventsService;
        }

        [ChildActionOnly]
        public virtual PartialViewResult YearEventsList()
        {
            return PartialView(MVC.YearEvents.Views.Partial._ListYearEvents, _yearEventsService.GetYearEvents());
        }

        #region Add YearEvents
        [HttpGet]
        public virtual ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Add(YearEvents model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _yearEventsService.Add(model);
            if (!result.IsSuccessfull)
            {
                this.NotificationController().Notify(result.Message, NotificationStatus.Error);
                return View(model);
            }
            return RedirectToAction(MVC.YearEvents.ActionNames.Add, MVC.YearEvents.Name);
        }
        #endregion
        #region Edit YearEvents
        [HttpGet]
        public virtual ViewResult Edit(int yearEventsId)
        {
            return View(_yearEventsService.Find(yearEventsId));
        }

        [HttpPost]
        public virtual ActionResult Edit(YearEvents model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _yearEventsService.Edit(model);
            if (!result.IsSuccessfull)
            {
                this.NotificationController().Notify(result.Message, NotificationStatus.Error);
                return View(model);
            }
            return RedirectToAction(MVC.YearEvents.ActionNames.Add, MVC.YearEvents.Name);
        }
        #endregion
        #region Delete
        [HttpPost]
        public virtual JsonResult Delete(int yearEventsId)
        {
            return Json(_yearEventsService.Delete(yearEventsId));
        }
        #endregion
    }
}
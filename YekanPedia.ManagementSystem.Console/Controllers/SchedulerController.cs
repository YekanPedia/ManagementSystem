namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Scheduler;
    using System.Linq;
    public partial class SchedulerController : Controller
    {
        readonly ISchedulerObserver _schedulerObserver;
        public SchedulerController(ISchedulerObserver schedulerObserver)
        {
            _schedulerObserver = schedulerObserver;
        }
        [HttpGet]
        public virtual JsonResult WakeUp()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public virtual PartialViewResult GetList()
        {
            return PartialView(MVC.Scheduler.Views.Partial._List, _schedulerObserver.CurrentScheduledTask);
        }

        [HttpPost]
        public virtual JsonResult Pause(string name, bool state)
        {
            var task = _schedulerObserver.CurrentScheduledTask.Where(X => X.Name == name).FirstOrDefault();
            if (task != null)
            {
                task.Pause = state;
            }
            return Json(true);
        }
    }
}
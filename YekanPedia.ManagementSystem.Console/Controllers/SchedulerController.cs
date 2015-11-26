namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    public class SchedulerController : Controller
    {
        [HttpGet]
        public virtual JsonResult WakeUp()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    public partial class ErrorController : Controller
    {
        [HttpGet]
        public virtual ActionResult Er404()
        {
            return View(Request.UrlReferrer);
        }
    }
}
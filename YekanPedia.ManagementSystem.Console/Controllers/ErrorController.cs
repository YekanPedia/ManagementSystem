namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    public partial class ErrorController : Controller
    {
        [HttpGet]
        public virtual ViewResult NotFound()
        {
            return View(Request.UrlReferrer);
        }

        [HttpGet]
        public virtual ViewResult Forbidden()
        {
            return View();
        }

    }
}
namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using IoFile = System.IO.File;
    public partial class GeographicController : Controller
    {
        [HttpGet, Route("Geographic/api/js")]
        public virtual ContentResult Js(string v)
        {
            return Content(IoFile.ReadAllText(Server.MapPath("~/Views/Geographic/" + v + "/default.html")), "text/javascript");
        }
    }
}
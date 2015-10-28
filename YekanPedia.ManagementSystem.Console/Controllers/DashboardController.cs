namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;

    public partial class DashboardController : Controller
    {

        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;

    public partial class OAuthController : Controller
    {
        [HttpGet]
        public virtual ViewResult SignIn()
        {
            return View();
        }
    }
}
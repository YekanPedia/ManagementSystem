namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System;
    using System.Web.Mvc;
    public partial class SettingController : Controller
    {

        [HttpGet]
        public virtual ViewResult Manage()
        {
            return View();
        }
    }
}
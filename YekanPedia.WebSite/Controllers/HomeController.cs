﻿namespace YekanPedia.WebSite.Controllers
{
    using System.Web.Mvc;
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
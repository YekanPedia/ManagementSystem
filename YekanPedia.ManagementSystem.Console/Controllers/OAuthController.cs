namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;
    using System.Web.Security;
    using System;
    using System.Web;

    public partial class OAuthController : Controller
    {
        #region Constructur
        private readonly IUserService _userServie;
        public OAuthController(IUserService userService)
        {
            _userServie = userService;
        }
        #endregion

        [HttpGet]
        public virtual ViewResult SignIn()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public virtual ActionResult SignIn(User model)
        {
            var login = _userServie.CheckUserExist(model.Email, model.Password);
            if (login.Result == null)
            {
                ModelState.Clear();
                model.AboutMe = "has-error";
                ModelState.AddModelError(nameof(model.Email), login.Message);
                ModelState.AddModelError(nameof(model.Password), login.Message);
                return View(model);
            }

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, login.Result.Email, DateTime.Now, DateTime.Now.AddHours(8), false, login.Result.Email);
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);
            return RedirectToAction(MVC.Dashboard.ActionNames.Index, MVC.Dashboard.Name);
        }
    }
}
namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;
    using System.Web.Security;
    using System;
    using System.Web;
    using System.Web.Script.Serialization;

    public partial class OAuthController : Controller
    {
        #region Constructur
        private readonly IUserService _userServie;
        public OAuthController(IUserService userService)
        {
            _userServie = userService;
        }
        #endregion
        #region SignIn
        [HttpGet, AllowAnonymous]
        public virtual ViewResult SignIn()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public virtual ActionResult SignIn(User model, bool rememberMe)
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

            var serializeModel = new BaseUser();
            serializeModel.FullName = login.Result.FullName;
            serializeModel.Email = login.Result.Email;
            serializeModel.UserId = login.Result.UserId;
            serializeModel.Picture = login.Result.Picture;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string userData = serializer.Serialize(serializeModel);

            int expire = rememberMe ? 43200 : 30;
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, login.Result.Email, DateTime.Now, DateTime.Now.AddMinutes(expire), rememberMe, userData);
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);

            return RedirectToAction(MVC.Dashboard.ActionNames.User, MVC.Dashboard.Name);
        }
        #endregion
        [HttpGet, AllowAnonymous]
        public virtual RedirectToRouteResult SignOut()
        {
            Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction(MVC.OAuth.ActionNames.SignIn, MVC.OAuth.Name);
        }
    }
}
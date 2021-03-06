﻿namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;
    using System.Web.Security;
    using System;
    using System.Web;
    using System.Web.Script.Serialization;
    using System.Linq;
    using InfraStructure.Extension.Authentication;

    public partial class OAuthController : Controller
    {
        #region Constructur
        readonly IUserService _userServie;
        readonly IRoleManagementService _roleManagementService;
        readonly ICurrentUserPrincipal _currentUser;
        public OAuthController(IUserService userService, IRoleManagementService roleManagementService, ICurrentUserPrincipal currentUser)
        {
            _currentUser = currentUser;
            _userServie = userService;
            _roleManagementService = roleManagementService;
        }
        #endregion
        #region SignIn
        [HttpGet, AllowAnonymous]
        public virtual ViewResult SignIn()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public virtual ActionResult SignIn(User model, bool rememberMe)
        {
            var login = _userServie.CheckUserExist(model.Email, model.Password);
            if (login.Result == null)
            {
                ModelState.Clear();
                model.AboutMe = "has-error";
                ModelState.AddModelError(nameof(model.Email), login.Message);
                return View(model);
            }

            _currentUser.FullName = login.Result.FullName;
            _currentUser.Email = login.Result.Email;
            _currentUser.UserId = login.Result.UserId;
            _currentUser.Picture = login.Result.Picture;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string userData = serializer.Serialize(_currentUser);

            int expire = rememberMe ? 43200 : 30;
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, login.Result.Email, DateTime.Now, DateTime.Now.AddMinutes(expire), rememberMe, userData);
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);

            var availableMenu = _roleManagementService.GetAvailableMenu(login.Result.UserId);
            //cache 
            var defaultPage = availableMenu.Where(X => X.IsFirstAction).FirstOrDefault();
            return RedirectToAction(defaultPage.ActionName, defaultPage.Controller);
        }
        #endregion
        [HttpGet, AllowAnonymous]
        public virtual RedirectToRouteResult SignOut()
        {
            HttpCookie oldCookie = new HttpCookie(".ASPXAUTH");
            oldCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(oldCookie);

            HttpCookie ASPNET_SessionId = new HttpCookie("ASP.NET_SessionId");
            ASPNET_SessionId.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ASPNET_SessionId);

            Session.Clear();
            return RedirectToAction(MVC.OAuth.ActionNames.SignIn, MVC.OAuth.Name);
        }
    }
}
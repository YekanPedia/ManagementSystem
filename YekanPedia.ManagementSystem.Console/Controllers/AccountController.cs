namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Domain.Entity;
    using Service.Interfaces;
    using InfraStructure;
    using System.Web.UI;
    using Extensions.Authentication;
    using System;

    using Resources;

    public partial class AccountController : Controller
    {
        #region Constructure
        private readonly IUserService _userService;
        private readonly IActionResults _actionResult;
        public AccountController(IUserService userService, IActionResults actionResult)
        {
            _userService = userService;
            _actionResult = actionResult;
        }
        #endregion
        #region Register
        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public virtual JsonResult Register(User model)
        {
            #region Check Email Exist
            var emailChecker = _userService.CheckEmailExist(model.Email);
            if (emailChecker.Result)
            {
                ModelState.AddModelError(nameof(model.Email), emailChecker.Message);
            }
            #endregion

            if (!ModelState.IsValid)
            {
                _actionResult.IsSuccessfull = false;
                _actionResult.Message = this.GetErrorsModelState();
                return Json(_actionResult);
            }
            model.UserId = Guid.NewGuid();
            var result = _userService.AddUser(model, new Tasks()
            {
                Link = Url.Action(MVC.Account.ActionNames.Profile, MVC.Account.Name, new { userId = model.UserId }),
                ProgressbarType = ProgressbarType.Primary,
                Progress = 0,
                Subject = LocalMessage.CompleteProfile,
                UserId = model.UserId,
                FinishDateMi = DateTime.Now.AddHours(3)
            });
            if (result.IsSuccessfull)
            {
                result.Message = Url.Action(MVC.Dashboard.ActionNames.User, controllerName: MVC.Dashboard.Name);
            }
            return Json(result);
        }
        #endregion
        #region Profile

        [ChildActionOnly]
        public virtual PartialViewResult ProfileWidget(Guid userId)
        {
            var result = _userService.FindUser(userId).Result;
            return PartialView(MVC.Account.Views.Partial._ProfileWidget, result);
        }

        [HttpGet, Route("Account/Profile/{userId}")]
        public virtual new ActionResult Profile(Guid userId)
        {
            var result = _userService.FindUser(userId).Result;
            if (result == null)
            {
                return RedirectToAction(MVC.Error.ActionNames.Er404, MVC.Error.Name);
            }
            return View(result);
        }

        [HttpPost]
        public virtual JsonResult EditAboutMe(Guid UserId, string AboutMe)
        {
            return Json(_userService.EditAboutMe(UserId, AboutMe));
        }

        [HttpPost]
        public virtual JsonResult EditBasicInfo(User model)
        {
            var result = _userService.EditBasicInfo(model);
            if (!result.IsSuccessfull)
            {
                _actionResult.IsSuccessfull = false;
                _actionResult.Message = this.GetErrorsModelState();
                return Json(_actionResult);
            }
            return Json(result);
        }

        [HttpPost]
        public virtual JsonResult EditCallInfo(User model)
        {
            var result = _userService.EditCallInfo(model);
            if (!result.IsSuccessfull)
            {
                _actionResult.IsSuccessfull = false;
                _actionResult.Message = this.GetErrorsModelState();
                return Json(_actionResult);
            }
            return Json(result);
        }
        #endregion
        #region Picture
        [HttpGet, Route("Account/ChangePicture/{userId}")]
        public virtual ActionResult ChangePicture(Guid userId)
        {
            var result = _userService.FindUser(userId).Result;
            if (result == null)
            {
                return RedirectToAction(MVC.Error.ActionNames.Er404, MVC.Error.Name);
            }
            return View(result);
        }

        [HttpPost]
        public virtual JsonResult ChangePicture(Guid userId, string picture)
        {
            var result = _userService.ChangePicture(userId, picture).Result;
            return Json(result);
        }
        #endregion
        #region Validation Email Cheker
        [HttpPost, OutputCache(NoStore = true, Location = OutputCacheLocation.None)]
        public virtual JsonResult EmailChecker(string email)
        {
            return Json(_userService.CheckEmailExist(email));
        }
        #endregion
        #region RecoveryPassword
        [HttpPost, AllowAnonymous]
        public virtual JsonResult RecoveryPassword(string email)
        {
            return Json(_userService.RecoveryPassword(email));
        }
        #endregion
    }
}
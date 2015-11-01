namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Domain.Entity;
    using Service.Interfaces;
    using InfraStructure;
    using System.Web.UI;
    using Extensions.Authentication;
    using System;
    using App_GlobalResources;

    public partial class AccountController : Controller
    {
        #region Constructure
        private readonly IUserService _userService;
        private readonly IActionResults _actionResult;
        private readonly ITaskService _taskService;

        public AccountController(IUserService userService, IActionResults actionResult, ITaskService taskService)
        {
            _userService = userService;
            _actionResult = actionResult;
            _taskService = taskService;
        }
        #endregion

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

            var result = _userService.AddUser(model);
            if (result.IsSuccessfull)
            {
                _taskService?.AddUserTask(new Tasks()
                {
                    Link = Url.Action(MVC.Account.ActionNames.Profile, MVC.Account.Name),
                    ProgressbarType = ProgressbarType.Primary,
                    Subject = LocalMessage.CompleteProfile,
                    UserId = result.Result
                });
                result.Message = Url.Action(MVC.Dashboard.ActionNames.User, controllerName: MVC.Dashboard.Name);
            }
            return Json(result);
        }

        #region Profile
        [HttpGet, Route("Account/Profile/{userId}")]
        public virtual new ActionResult Profile(Guid userId)
        {
            var result = _userService.FindUser(userId).Result;
            if (result == null)
            {
                return RedirectToAction(MVC.Dashboard.ActionNames.NotFound, MVC.Dashboard.Name);
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
                return RedirectToAction(MVC.Dashboard.ActionNames.NotFound, MVC.Dashboard.Name);
            }
            return View(result);
        }
        #endregion
        [HttpPost, OutputCache(NoStore = true, Location = OutputCacheLocation.None)]
        public virtual JsonResult EmailChecker(string email)
        {
            return Json(_userService.CheckEmailExist(email));
        }
    }
}
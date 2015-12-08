namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Domain.Entity;
    using Service.Interfaces;
    using InfraStructure;
    using System.Web.UI;
    using System;
    using Resources;
    using System.Web;
    using System.Linq;
    using ExternalService.Interfaces;
    using ExternalService.FilesProxy;
    using System.IO;

    public partial class AccountController : Controller
    {
        #region Constructure
        readonly IUserService _userService;
        readonly IActionResults _actionResult;
        readonly Lazy<IFilesProxyAdapter> _fileProxy;
        public AccountController(IUserService userService, IActionResults actionResult, Lazy<IFilesProxyAdapter> fileProxy)
        {
            _fileProxy = fileProxy;
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
                return RedirectToAction(MVC.Error.ActionNames.NotFound, MVC.Error.Name);
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
                return RedirectToAction(MVC.Error.ActionNames.NotFound, MVC.Error.Name);
            }
            return View(result);
        }

        [HttpPost]
        public virtual JsonResult ChangePicture(Guid userId, string picture)
        {
            var result = _userService.ChangePicture(userId, picture).Result;
            return Json(result);
        }

        [HttpPost]
        public virtual ActionResult UploadUserPicture(HttpPostedFileBase file, Guid userId, float x, float y, float width, float height)
        {
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            var imageAddress = _fileProxy.Value.UploadImage(new PostedImageFile
            { 
                Content = fileData,
                FileName = $"{userId}.{file.FileName.Split('.').Last()}",
                Height = (int)Math.Ceiling(height),
                Width = (int)Math.Ceiling(width),
                X = (int)Math.Ceiling(x),
                Y = (int)Math.Ceiling(y)
            });
            if (!string.IsNullOrEmpty(imageAddress))
            {
                _userService.ChangePicture(userId, imageAddress);
            }
            return RedirectToAction(MVC.Account.ActionNames.ChangePicture, MVC.Account.Name, new { userId = userId });
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
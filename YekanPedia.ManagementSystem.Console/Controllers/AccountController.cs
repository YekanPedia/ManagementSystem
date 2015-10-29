namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Domain.Entity;
    using Service.Interfaces;
    using InfraStructure;
    using System.Web.UI;

    public partial class AccountController : Controller
    {
        #region Constructure
        private readonly IUserService _userService;
        private readonly IActionResult _actionResult;
        public AccountController(IUserService userService, IActionResult actionResult)
        {
            _userService = userService;
            _actionResult = actionResult;
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
                result.Message = Url.Action(MVC.Dashboard.ActionNames.User, controllerName: MVC.Dashboard.Name);
            return Json(result);
        }

        #region Profile
        public virtual ViewResult Profile()
        {
            return View();
        }
        #endregion


        [HttpPost, OutputCache(NoStore = true, Location = OutputCacheLocation.None), ValidateAntiForgeryToken]
        public virtual JsonResult EmailChecker(string email)
        {
            return Json(_userService.CheckEmailExist(email));
        }
    }
}
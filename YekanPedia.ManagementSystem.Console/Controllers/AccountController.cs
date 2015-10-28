namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Domain.Entity;
    using Service.Interfaces;
    using InfraStructure;

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

        [HttpPost]
        public virtual JsonResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.AddUser(model);
                if (result.IsSuccessfull)
                    result.Message = Url.Action(MVC.Dashboard.ActionNames.Index, controllerName: MVC.Dashboard.Name);
                return Json(result);
            }
            _actionResult.IsSuccessfull = false;
            _actionResult.Message = this.GetErrorsModelState();
            return Json(_actionResult);
        }
    }
}
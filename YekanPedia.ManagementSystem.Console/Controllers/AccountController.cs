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
                return Json(_userService.AddUser(model));
            }
            _actionResult.IsSuccessfull = false;
            _actionResult.Message = "";
            return Json(_actionResult);
        }
    }
}
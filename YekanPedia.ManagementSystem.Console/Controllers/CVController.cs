namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System;
    using System.Web.Mvc;
    using Service.Interfaces;

    public partial class CVController : Controller
    {
        #region Constructure
        readonly IUserService _userService;
        readonly Lazy<IEducationService> _educationService;
        readonly Lazy<IWorkService> _workService;
        readonly Lazy<ISkillsService> _skillsService;

        public CVController(IUserService userService, Lazy<IEducationService> educationService, Lazy<IWorkService> workService, Lazy<ISkillsService> skillsService)
        {
            _userService = userService;
            _workService = workService;
            _educationService = educationService;
            _skillsService = skillsService;
        }
        #endregion

        [HttpGet, Route("CV/User/{userId}")]
        public new virtual ViewResult User(Guid userId)
        {
            return View(_userService.GetUserCV(userId));
        }
    }
}
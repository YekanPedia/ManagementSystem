namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Domain.Entity;
    using Service.Interfaces;

    public partial class ClassController : Controller
    {
        #region Constructure
        private readonly IUserService _userService;
        public ClassController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        [HttpGet]
        public virtual ViewResult Add()
        {
            ViewBag.Teacher = new SelectList(_userService.GetTeachers().Result);
            return View();
        }

        [HttpPost]
        public virtual ViewResult Add(Class model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View();
        }

    }
}
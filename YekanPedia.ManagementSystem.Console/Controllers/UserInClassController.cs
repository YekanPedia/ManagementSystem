namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System;
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;
    using System.Linq;

    public partial class UserInClassController : Controller
    {
        #region Constructure
        readonly IUserInClassService _userInClassService;
        readonly IClassService _classService;
        public UserInClassController(IUserInClassService userInClassService, IClassService classService)
        {
            _userInClassService = userInClassService;
            _classService = classService;
        }
        #endregion

        [ChildActionOnly]
        public virtual PartialViewResult List(Guid userId)
        {
            return PartialView(MVC.UserInClass.Views.Partial._List, _userInClassService.GetAllUserClass(userId));
        }

        [HttpGet]
        public virtual ViewResult Add(Guid userId)
        {
            ViewBag.Class = _classService.GetClass().Select(x => new SelectListItem
            {
                Text = x.ClassInformaion,
                Value = x.ClassId.ToString()
            });
            return View(new UserInClass { UserId = userId });
        }

        [HttpPost]
        public virtual ViewResult Add(UserInClass model)
        {

            return View(model);
        }
    }
}
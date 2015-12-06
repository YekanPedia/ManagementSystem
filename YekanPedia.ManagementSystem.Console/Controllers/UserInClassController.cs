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
        void ClassDropDownList()
        {
            ViewBag.Class = _classService.GetClass().Select(x => new SelectListItem
            {
                Text = x.ClassInformaion,
                Value = x.ClassId.ToString()
            });
        }

        #region Add
        [HttpGet]
        public virtual ViewResult Add(Guid userId)
        {
            ClassDropDownList();
            return View(new UserInClass { UserId = userId });
        }
        [HttpPost]
        public virtual ActionResult Add(UserInClass model)
        {
            ClassDropDownList();
            if (!ModelState.IsValid)
                return View(model);
            var result = _userInClassService.Add(model);
            if (!result.IsSuccessfull)
            {
                this.NotificationController().Notify(result.Message, NotificationStatus.Error);
                return View(model);
            }
            return RedirectToAction(MVC.UserInClass.ActionNames.Add, MVC.UserInClass.Name, new { userId = (Guid)model.UserId });
        }
        #endregion
        #region Edit
        [HttpGet]
        public virtual ViewResult Edit(int userInClassId)
        {
            ClassDropDownList();
            return View(_userInClassService.Find(userInClassId));
        }

        [HttpPost]
        public virtual ActionResult Edit(UserInClass model)
        {
            ClassDropDownList();
            if (!ModelState.IsValid)
                return View(model);
            var result = _userInClassService.Edit(model);
            if (!result.IsSuccessfull)
            {
                this.NotificationController().Notify(result.Message, NotificationStatus.Error);
                return View(model);
            }
            return RedirectToAction(MVC.UserInClass.ActionNames.Add, MVC.UserInClass.Name, new { userId = model.UserId });
        }
        #endregion
        #region Delete
        [HttpPost]
        public virtual JsonResult Delete(int userInClassId)
        {
            return Json(_userInClassService.Delete(userInClassId));
        }
        #endregion

        [ChildActionOnly, OutputCache(Duration = 3600 * 5)]
        public virtual PartialViewResult UserExpired()
        {
            return PartialView(MVC.UserInClass.Views.Partial._UserExpired, _userInClassService.GetExpiredUser());
        }
    }
}
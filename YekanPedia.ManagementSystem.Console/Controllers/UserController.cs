namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using System.Linq;
    using Domain.Entity;
    using System;
    using System.Collections.Generic;
    using Resources;
    using InfraStructure.Extension.Authentication;
    using System.Net;
    using System.Collections.Specialized;
    using System.Text;
    using System.IO;

    public partial class UserController : Controller
    {
        #region Constructure
        readonly IUserService _userService;
        readonly IClassService _classService;
        public UserController(IUserService userService, IClassService classService)
        {
            _classService = classService;
            _userService = userService;
        }
        #endregion
        public virtual PartialViewResult Search(User model, Guid? classId)
        {
            var resultModel = _userService.GetUsers(model, classId).Result;
            return PartialView(MVC.User.Views.Partial._List, resultModel);
        }

        [HttpGet]
        public virtual ViewResult Manage()
        {
            ViewBag.Class = new List<SelectListItem>();
            ((List<SelectListItem>)(ViewBag.Class)).Add(new SelectListItem { Text = LocalMessage.EmptySelect, Value = string.Empty });
            ((List<SelectListItem>)(ViewBag.Class)).AddRange(_classService.GetClass().Select(x => new SelectListItem
            {
                Text = x.ClassInformaion,
                Value = x.ClassId.ToString()
            }).ToList());
            return View();
        }
        public virtual JsonResult ChangeState(Guid userId, bool status)
        {
            return Json(_userService.ChangeStatus(userId, status));
        }

        [ChildActionOnly]
        public virtual PartialViewResult Friends()
        {
            return PartialView(MVC.User.Views.Partial._Friends, _userService.GetFriends((User as ICurrentUserPrincipal).UserId));
        }
    }
}
namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System;
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;
    using App_GlobalResources;

    public partial class SessionController : Controller
    {
        #region Constructure
        readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        #endregion

        [ChildActionOnly]
        public virtual PartialViewResult SessionBlock(Guid classId)
        {
            return PartialView(MVC.Session.Views.Partial._SessionBlock, _sessionService.GetSessions(classId));
        }

        [Route("Session/Block/{classId}")]
        public virtual ViewResult Block(Guid classId)
        {
            return View(classId);
        }

        [ChildActionOnly]
        public virtual PartialViewResult SessionList(Guid classId)
        {
            return PartialView(MVC.Session.Views.Partial._SessionList, _sessionService.GetSessions(classId));
        }

        #region Add
        [HttpGet]
        public virtual ViewResult Add(Guid classId)
        {
            return View(new ClassSession { ClassId = classId });
        }

        [HttpPost]
        public virtual ActionResult Add(ClassSession model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.ReBind();
            var result = _sessionService.AddClassSession(model);
            if (!result.IsSuccessfull)
            {
                this.NotificationController().Notify(result.Message, NotificationStatus.Error);
                return View(model);
            }
            this.NotificationController().Notify(string.Format(LocalMessage.SessionMaterialAddress, result.Message), NotificationStatus.Success);
            return RedirectToAction(MVC.Session.ActionNames.Add, MVC.Session.Name, new
            {
                classId = model.ClassId
            });
        }
        #endregion
        #region Edit
        [HttpGet]
        public virtual ViewResult Edit(Guid sessionId)
        {
            return View(_sessionService.Find(sessionId).Result);
        }

        [HttpPost]
        public virtual ActionResult Edit(ClassSession model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.ReBind();
            var result = _sessionService.EditClassSession(model);
            if (!result.IsSuccessfull)
            {
                this.NotificationController().Notify(result.Message, NotificationStatus.Error);
                return View(model);
            }
            return RedirectToAction(MVC.Session.ActionNames.Add, MVC.Session.Name, new
            {
                classId = model.ClassId
            });
        }
        #endregion
        #region Delete
        [HttpPost]
        public virtual JsonResult Delete(Guid sessionId)
        {
            return Json(_sessionService.DeleteClassSession(sessionId));
        }

        #endregion
        #region Notification
        [HttpPost]
        public virtual JsonResult SendNotification(Guid sessionId)
        {
            var session = _sessionService.Find(sessionId);
            if (session.IsSuccessfull)
                return Json(_sessionService.SendNotification(session.Result.ClassId, session.Result.ClassSessionDateSh, session.Result.IsCanceled));
            return Json(session);
        }
        #endregion
        #region File Management
        [HttpPost]
        public virtual JsonResult SyncMaterial(Guid sessionId)
        {
            return Json(_sessionService.SyncMaterial(sessionId));
        }

        [HttpPost]
        public virtual JsonResult DirectoryAddress(Guid sessionId)
        {
            return Json(string.Format(LocalMessage.SessionMaterialAddress, _sessionService.GetDirectoryAddress(sessionId)));
        }
        #endregion
    }
}
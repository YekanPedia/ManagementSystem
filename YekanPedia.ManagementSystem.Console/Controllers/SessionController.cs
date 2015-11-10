namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System;
    using System.Web.Mvc;
    using Service.Interfaces;

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
        public virtual PartialViewResult SessionList(Guid classId)
        {
            return PartialView(MVC.Session.Views.Partial._SessionList, _sessionService.GetSessions(classId));
        }

        [Route("Session/List/{classId}")]
        public virtual ViewResult List(Guid classId)
        {
            return View(classId);
        }
    }
}
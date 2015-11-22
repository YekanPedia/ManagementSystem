namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Domain.Entity;
    using Service.Interfaces;
    using InfraStructure.Date;
    using System;
    using Extensions.Authentication;

    public partial class SessionRequestController : Controller
    {
        #region Constructure
        readonly ISessionRequestService _sessionRequestService;
        public SessionRequestController(ISessionRequestService sessionRequestService)
        {
            _sessionRequestService = sessionRequestService;
        }
        #endregion

        [HttpPost]
        public virtual JsonResult Add(SessionRequest model)
        {
            model.RquestDateSh = PersianDateTime.Now.ToString(PersianDateTimeFormat.Date);
            model.RquestDateMi = DateTime.Now;
            model.UserId = (User as ICurrentUserPrincipal).UserId;
            return Json(_sessionRequestService.Add(model));
        }
    }
}
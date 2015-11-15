namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using System;
    using Domain.Entity;

    public partial class NotificationController : Controller
    {
        #region Constructure
        readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        #endregion

        [HttpPost]
        public virtual JsonResult SendToUser(Guid userId, string message)
        {
            return Json(_notificationService.SendNotificationToUser(userId, NotificationType.PrivateMessage, message));
        }
    }
}
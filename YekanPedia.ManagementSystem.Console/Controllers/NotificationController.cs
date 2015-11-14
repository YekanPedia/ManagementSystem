namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System;
    using System.Web.Mvc;
    using Service.Interfaces;
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

        [ChildActionOnly]
        public virtual PartialViewResult GetNotificationSetting()
        {
            return PartialView(MVC.Notification.Views.Partial._GetNotificationSetting,_notificationService.GetAllNotification());
        }
    }
}
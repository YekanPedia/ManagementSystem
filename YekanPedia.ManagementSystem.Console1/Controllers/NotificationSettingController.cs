namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System;
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;

    public partial class NotificationSettingController : Controller
    {
        #region Constructure
        readonly INotificationSettingService _notificationSettingService;
        public NotificationSettingController(INotificationSettingService notificationSettingService)
        {
            _notificationSettingService = notificationSettingService;
        }
        #endregion

      
        [ChildActionOnly]
        public virtual PartialViewResult AllNotificationSetting()
        {
            return PartialView(MVC.NotificationSetting.Views.Partial._AllNotificationSetting,_notificationSettingService.GetAllNotification());
        }

        [HttpPost]
        public virtual JsonResult Edit(NotificationSetting model)
        {
            return Json(_notificationSettingService.Edit(model));
        }
    }
}
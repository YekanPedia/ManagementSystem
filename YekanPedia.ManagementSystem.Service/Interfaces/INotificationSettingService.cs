namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using Domain.Entity;
    using System.Collections.Generic;
    using System;
    using InfraStructure;

    public interface INotificationSettingService
    {
        IEnumerable<NotificationSetting> GetAllNotification();
        IServiceResults<int> Edit(NotificationSetting model);
        NotificationSetting GetNotificationType(NotificationType type);
    }
}

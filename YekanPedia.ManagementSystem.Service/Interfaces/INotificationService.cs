namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using Domain.Entity;
    using System.Collections.Generic;
    using System;
    using InfraStructure;

    public interface INotificationService
    {
        IEnumerable<Notification> GetAllNotification();
        IServiceResults<bool> SendNotificationToUser(Guid userId,NotificationType notificationType, string message);
        IServiceResults<bool> SendNotificationToClass(Guid classId, NotificationType notificationType, string message);
        IServiceResults<bool> SendNotificationToBirthDateUser();
    }
}

namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using InfraStructure;
    using Domain.Entity;
    using System.Collections.Generic;

    public interface INotificationService
    {
        IServiceResults<bool> SendNotificationToUser(Guid userId, NotificationType notificationType, string message);
        IServiceResults<bool> SendPrivateNotificationToClass(Guid classId, NotificationType notificationType, string message);
        IServiceResults<bool> SendNotificationToClass(Guid classId, NotificationType notificationType, string date);
        IServiceResults<bool> SendNotificationToBirthDateUser(IEnumerable<User> users);
        IServiceResults<bool> SendYearEventMessage(IEnumerable<User> users,NotificationType notificationType, string message);
    }
}

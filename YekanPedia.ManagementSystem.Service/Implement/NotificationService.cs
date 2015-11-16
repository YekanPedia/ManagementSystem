namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using InfraStructure;
    using Interfaces;
    using Domain.Entity;
    using Properties;
    using ExternalService.Interfaces;
    using System.Data.Entity;
    using Data.Conext;
    using ExternalService.MessagingGateway;

    public class NotificationService : INotificationService
    {
        #region Constructur
        readonly IUnitOfWork _uow;
        readonly IDbSet<WebSiteNotification> _websiteNotification;
        readonly IUserService _userService;
        readonly IMessagingGatewayAdapter _messagingGateway;
        readonly INotificationSettingService _notificationSettingService;
        public NotificationService(IUnitOfWork uow, IUserService userService, IMessagingGatewayAdapter messagingGateway, INotificationSettingService notificationSettingService)
        {
            _uow = uow;
            _websiteNotification = uow.Set<WebSiteNotification>();
            _userService = userService;
            _messagingGateway = messagingGateway;
            _notificationSettingService = notificationSettingService;
        }
        #endregion
        public IServiceResults<bool> SendNotificationToUser(Guid userId, NotificationType notificationType, string message)
        {
            var user = _userService.FindUser(userId);
            if (user.Result == null)
                return new ServiceResults<bool>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.Error,
                    Result = false
                };

            var notification = _notificationSettingService.GetNotificationType(notificationType);
            var sms = new List<string>();
            var telegram = new List<int>();
            var email = new List<string>();
            var type = new NotificationKey();
            if (notification.Email)
            {
                type.Email = true;
                email.Add(user.Result.Email);
            }

            if (notification.Sms)
            {
                type.Sms = true;
                sms.Add(user.Result.Mobile);
            }

            if (notification.Telegram && user.Result.Telegram != null)
            {
                type.Telegram = true;
                telegram.Add(user.Result.Telegram);
            }
            _messagingGateway.GivenMessages(new NotificationPackage
            {
                Message = new List<string> { message },
                Type = new List<NotificationKey> { type },
                Sms = sms,
                Telegram = telegram,
                Email = email
            });

            return new ServiceResults<bool>
            {
                IsSuccessfull = true,
                Message = "",
                Result = true
            };
        }
        public IServiceResults<bool> SendNotificationToClass(Guid classId, NotificationType notificationType, string message)
        {
            throw new NotImplementedException();
        }
        public IServiceResults<bool> SendNotificationToBirthDateUser()
        {
            throw new NotImplementedException();
        }

    }
}

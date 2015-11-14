namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;
    using System.Linq;
    using System;
    using ExternalService.Interfaces;
    using ExternalService.MessagingGateway;
    using InfraStructure;
    using Properties;

    public class NotificationService : INotificationService
    {
        #region Constructur
        readonly IUnitOfWork _uow;
        readonly IDbSet<Notification> _notification;
        readonly IUserService _userService;
        readonly IMessagingGatewayAdapter _messagingGateway;
        public NotificationService(IUnitOfWork uow, IUserService userService, IMessagingGatewayAdapter messagingGateway)
        {
            _uow = uow;
            _notification = uow.Set<Notification>();
            _userService = userService;
            _messagingGateway = messagingGateway;
        }
        #endregion

        public IEnumerable<Notification> GetAllNotification()
        {
            return _notification.AsNoTracking().ToList();
        }

        public Notification GetNotificationType(NotificationType type)
        {
            return _notification.Where(X => X.NotificationType == type).AsNoTracking().FirstOrDefault();
        }

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

            var notification = GetNotificationType(notificationType);
            var sms = new List<string>();
            var telegram = new List<string>();
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

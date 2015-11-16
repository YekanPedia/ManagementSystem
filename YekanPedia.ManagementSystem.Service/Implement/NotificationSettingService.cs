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

    public class NotificationSettingService : INotificationSettingService
    {
        #region Constructur
        readonly IUnitOfWork _uow;
        readonly IDbSet<NotificationSetting> _notification;
        readonly IUserService _userService;
        readonly IMessagingGatewayAdapter _messagingGateway;
        public NotificationSettingService(IUnitOfWork uow, IUserService userService, IMessagingGatewayAdapter messagingGateway)
        {
            _uow = uow;
            _notification = uow.Set<NotificationSetting>();
            _userService = userService;
            _messagingGateway = messagingGateway;
        }
        #endregion
        public IEnumerable<NotificationSetting> GetAllNotification()
        {
            return _notification.AsNoTracking().ToList();
        }
        public NotificationSetting GetNotificationType(NotificationType type)
        {
            return _notification.Where(X => X.NotificationType == type).AsNoTracking().FirstOrDefault();
        }
        public IServiceResults<int> Edit(NotificationSetting model)
        {
            _notification.Attach(model);
            _uow.Entry(model).State = EntityState.Modified;
            var resultSave = _uow.SaveChanges();
            return new ServiceResults<int>
            {
                IsSuccessfull = resultSave.ToBool(),
                Message = resultSave.ToMessage(BusinessMessage.Error),
                Result = model.NotificationSettingId
            };
        }
    }
}

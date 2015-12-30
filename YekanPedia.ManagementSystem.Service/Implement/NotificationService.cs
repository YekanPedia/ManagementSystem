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
    using Data.Context;
    using ExternalService.MessagingGateway;
    using System.Threading;

    public class NotificationService : INotificationService
    {
        #region Constructur
        readonly IUnitOfWork _uow;
        readonly IDbSet<WebNotification> _webNotification;
        readonly IUserService _userService;
        readonly Lazy<IClassService> _classService;
        readonly Lazy<ISettingService> _settingService;
        readonly Lazy<IYearEventsService> _yearEventService;
        readonly IMessagingGatewayAdapter _messagingGateway;
        readonly INotificationSettingService _notificationSettingService;
        public NotificationService(IUnitOfWork uow,
            IUserService userService,
            IMessagingGatewayAdapter messagingGateway,
            INotificationSettingService notificationSettingService,
            Lazy<IClassService> classService,
            Lazy<ISettingService> settingService,
              Lazy<IYearEventsService> yearEventService
            )
        {
            _classService = classService;
            _uow = uow;
            _webNotification = uow.Set<WebNotification>();
            _userService = userService;
            _messagingGateway = messagingGateway;
            _notificationSettingService = notificationSettingService;
            _settingService = settingService;
            _yearEventService = yearEventService;
        }

        #endregion
        public IServiceResults<bool> SendNotificationToUser(Guid userId, NotificationType notificationType, string message)
        {
            try
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

                if (notification.Telegram && user.Result.Telegram != 0)
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
                    Message = string.Empty,
                    Result = true
                };
            }
            catch (Exception)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.NotificationNotSend,
                    Result = false
                };
            }
        }
        public IServiceResults<bool> SendNotificationToClass(Guid classId, NotificationType notificationType, string date)
        {
            try
            {
                var classData = _classService.Value.FindFullClassData(classId);
                var users = _userService.GetUsers(null, classId);
                if (classData != null)
                {
                    var notification = _notificationSettingService.GetNotificationType(notificationType);
                    var sms = new List<string>();
                    var telegram = new List<int>();
                    var email = new List<string>();

                    var types = new List<NotificationKey>();
                    foreach (var item in users.Result)
                    {
                        sms.Add(notification.Sms ? item.Mobile : string.Empty);
                        telegram.Add(notification.Telegram ? item.Telegram : 0);
                        email.Add(notification.Email ? item.Email : string.Empty);
                        types.Add(new NotificationKey
                        {
                            Email = notification.Email,
                            Sms = notification.Sms,
                            Telegram = notification.Telegram
                        });
                    }
                    _messagingGateway.GivenMessages(new NotificationPackage
                    {
                        Message = new List<string> { notificationType == NotificationType.CanceledClass ? classData.CanceledSessionNotification(date) : classData.AddSessionNotification(date) },
                        Type = types,
                        Sms = sms,
                        Telegram = telegram,
                        Email = email
                    });
                }
                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = string.Empty,
                    Result = true
                };
            }
            catch (Exception)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.NotificationNotSend,
                    Result = false
                };
            }
        }
        public IServiceResults<bool> SendNotificationToBirthDateUser(IEnumerable<User> users)
        {
            try
            {
                var notification = _notificationSettingService.GetNotificationType(NotificationType.BirthDate);
                var sms = new List<string>();
                var telegram = new List<int>();
                var email = new List<string>();
                var types = new List<NotificationKey>();
                foreach (var item in users)
                {
                    sms.Add(notification.Sms ? item.Mobile : string.Empty);
                    telegram.Add(notification.Telegram ? item.Telegram : 0);
                    email.Add(notification.Email ? item.Email : string.Empty);
                    types.Add(new NotificationKey
                    {
                        Email = notification.Email,
                        Sms = notification.Sms,
                        Telegram = notification.Telegram
                    });
                }
                _messagingGateway.GivenMessages(new NotificationPackage
                {
                    Message = new List<string> { _settingService.Value.GetDefaultSetting()?.BirthDateText },
                    Type = types,
                    Sms = sms,
                    Telegram = telegram,
                    Email = email
                });

                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = string.Empty,
                    Result = true
                };
            }
            catch (Exception)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.NotificationNotSend,
                    Result = false
                };
            }
        }
        public IServiceResults<bool> SendPrivateNotificationToClass(Guid classId, NotificationType notificationType, string message)
        {
            try
            {
                var classData = _classService.Value.FindFullClassData(classId);
                var users = _userService.GetUsers(null, classId);
                if (classData != null)
                {
                    var notification = _notificationSettingService.GetNotificationType(notificationType);
                    var sms = new List<string>();
                    var telegram = new List<int>();
                    var email = new List<string>();

                    var types = new List<NotificationKey>();
                    foreach (var item in users.Result)
                    {
                        sms.Add(notification.Sms ? item.Mobile : string.Empty);
                        telegram.Add(notification.Telegram ? item.Telegram : 0);
                        email.Add(notification.Email ? item.Email : string.Empty);
                        types.Add(new NotificationKey
                        {
                            Email = notification.Email,
                            Sms = notification.Sms,
                            Telegram = notification.Telegram
                        });
                    }
                    _messagingGateway.GivenMessages(new NotificationPackage
                    {
                        Message = new List<string> { message },
                        Type = types,
                        Sms = sms,
                        Telegram = telegram,
                        Email = email
                    });
                }
                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = string.Empty,
                    Result = true
                };
            }
            catch (Exception)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.NotificationNotSend,
                    Result = false
                };
            }
        }

        public IServiceResults<bool> SendYearEventMessage(IEnumerable<User> users, NotificationType notificationType, string message)
        {
            try
            {
                var notification = _notificationSettingService.GetNotificationType(notificationType);
                var sms = new List<string>();
                var telegram = new List<int>();
                var email = new List<string>();
                var types = new List<NotificationKey>();
                var count = 1;
                foreach (var item in users)
                {
                    sms.Add(notification.Sms ? item.Mobile : string.Empty);
                    telegram.Add(notification.Telegram ? item.Telegram : 0);
                    email.Add(notification.Email ? item.Email : string.Empty);
                    types.Add(new NotificationKey
                    {
                        Email = notification.Email,
                        Sms = notification.Sms,
                        Telegram = notification.Telegram
                    });
                    if (count == 100)
                    {
                        _messagingGateway.GivenMessages(new NotificationPackage
                        {
                            Message = new List<string> { message },
                            Type = types,
                            Sms = sms,
                            Telegram = telegram,
                            Email = email
                        });
                        sms = new List<string>();
                        telegram = new List<int>();
                        email = new List<string>();
                        types = new List<NotificationKey>();
                        count = 0;
                        Thread.Sleep(30 * 1000);
                    }
                    count++;
                }
                if (types.Count > 0)
                {
                    _messagingGateway.GivenMessages(new NotificationPackage
                    {
                        Message = new List<string> { message },
                        Type = types,
                        Sms = sms,
                        Telegram = telegram,
                        Email = email
                    });
                }

                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = string.Empty,
                    Result = true
                };
            }
            catch (Exception)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.NotificationNotSend,
                    Result = false
                };
            }
        }
    }
}

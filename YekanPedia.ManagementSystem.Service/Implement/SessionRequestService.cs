namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Context;
    using Domain.Entity;
    using InfraStructure;
    using Interfaces;
    using System.Data.Entity;
    using Properties;

    public class SessionRequestService : ISessionRequestService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<SessionRequest> _sessionRequest;
        readonly Lazy<INotificationService> _notificationService;
        readonly ISessionService _sessionService;
        public SessionRequestService(IUnitOfWork uow, Lazy<INotificationService> notificationService, ISessionService sessionService)
        {
            _sessionService = sessionService;
            _notificationService = notificationService;
            _uow = uow;
            _sessionRequest = uow.Set<SessionRequest>();
        }
        #endregion
        public IServiceResults<Guid> Add(SessionRequest model)
        {
            if (IsUnique(model.ClassSessionId, (Guid)model.UserId))
                return new ServiceResults<Guid>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.RecordExist,
                    Result = model.SessionRequestId
                };

            model.SessionRequestId = Guid.NewGuid();
            _sessionRequest.Add(model);
            var saveResult = _uow.SaveChanges();

            return new ServiceResults<Guid>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToBool() ? BusinessMessage.Ok : BusinessMessage.Error,
                Result = model.SessionRequestId
            };
        }
        public IEnumerable<SessionRequest> GetAllSessionRequest()
        {
            return _sessionRequest.Include(X => X.User)
                .Include(X => X.ClassSession)
                .Include(X => X.ClassSession.Class)
                .Include(X => X.ClassSession.Class.ClassTime)
                .Include(X => X.ClassSession.Class.Course)
                .OrderByDescending(X => X.RquestDateMi)
                .AsNoTracking()
                .ToList();
        }
        public IServiceResults<bool> Remove(Guid sessionRequestId)
        {
            var request = Find(sessionRequestId);
            var userId = request.UserId;
            var sessionId = request.ClassSessionId;
            _sessionRequest.Remove(request);
            var result = _uow.SaveChanges();
            if (result.ToBool())
            {
                var session = _sessionService.Find(sessionId);
                _notificationService.Value.SendNotificationToUser((Guid)userId, NotificationType.PrivateMessage, string.Format(BusinessMessage.RequestDone, session.Result.ClassSessionDateSh, session.Result.Subject));
            }
            return new ServiceResults<bool>
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result.ToBool()
            };
        }
        public SessionRequest Find(Guid sessionRequestId)
        {
            return _sessionRequest.Find(sessionRequestId);
        }

        public bool IsUnique(Guid classSessionId, Guid userId)
        {
            return _sessionRequest.Count(X => X.UserId == userId && X.ClassSessionId == classSessionId) != 0;
        }
    }
}

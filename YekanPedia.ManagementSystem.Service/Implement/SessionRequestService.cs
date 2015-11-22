namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Conext;
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
        public SessionRequestService(IUnitOfWork uow)
        {
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
        public IEnumerable<SessionRequest> GetAllSessionRequest(Guid sessionId)
        {
            return _sessionRequest.Where(X => X.ClassSessionId == sessionId)
                                  .OrderByDescending(X => X.RquestDateMi)
                                  .ToList();
        }
        public IServiceResults<bool> Remove(Guid sessionRequestId)
        {
            _sessionRequest.Remove(Find(sessionRequestId));
            var result = _uow.SaveChanges();
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

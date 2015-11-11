namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using InfraStructure;
    using System.Data.Entity;
    using Data.Conext;
    using Properties;
    using System.Linq;

    public class SessionService : ISessionService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<ClassSession> _classSession;
        readonly IClassService _classService;
        public SessionService(IUnitOfWork uow, IClassService classService)
        {
            _uow = uow;
            _classService = classService;
            _classSession = uow.Set<ClassSession>();
        }
        #endregion

        public IServiceResults<Guid> AddClassSession(ClassSession model)
        {
            model.ClassSessionId = Guid.NewGuid();
            _classSession.Add(model);
            var saveResult = _uow.SaveChanges();
            if (saveResult.ToBool() && GetSessionsCount(model.ClassId) == _classService.FindClass(model.ClassId)?.SessionCount)
            {
                _classService.FinishedClass(model.ClassId);
            }

            return new ServiceResults<Guid>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = model.ClassSessionId
            };
        }

        public IEnumerable<ClassSession> GetSessions(Guid classId)
        {
            return _classSession.Where(X => X.ClassId == classId)
                .OrderBy(X => X.ClassSessionDateSh)
                .AsNoTracking()
                .ToList();
        }
        public int GetSessionsCount(Guid classId)
        {
            return _classSession.Count(X => X.ClassId == classId && X.IsCanceled != false) * 2;
        }
    }
}

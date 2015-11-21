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
    using InfraStructure.Date;
    using ExternalService.Interfaces;

    public class SessionService : ISessionService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<ClassSession> _classSession;
        readonly IClassService _classService;
        readonly ISessionMaterialService _sessionMaterial;
        readonly IFilesProxyAdapter _filesProxyAdapter;
        readonly Lazy<INotificationService> _notificationService;
        public SessionService(IUnitOfWork uow,
            IClassService classService,
            ISessionMaterialService sessionMaterial,
            Lazy<INotificationService> notificationService,
            IFilesProxyAdapter filesProxyAdapter)
        {
            _uow = uow;
            _classService = classService;
            _classSession = uow.Set<ClassSession>();
            _notificationService = notificationService;
            _filesProxyAdapter = filesProxyAdapter;
            _sessionMaterial = sessionMaterial;
        }
        #endregion

        public IServiceResults<Guid> AddClassSession(ClassSession model)
        {
            model.ClassSessionId = Guid.NewGuid();
            _classSession.Add(model);
            var saveResult = _uow.SaveChanges();
            if (saveResult.ToBool() && GetSessionsCount(model.ClassId) == _classService.FindClass(model.ClassId)?.SessionCount)
                _classService.FinishedClass(model.ClassId);

            if (saveResult.ToBool())
                SendNotification(model.ClassId, model.ClassSessionDateSh, model.IsCanceled);
            string resultFileProxy = string.Empty;
            if (saveResult.ToBool())
            {
                var _class = _classService.FindFullClassData(model.ClassId);
                var time = PersianDateTime.Parse(model.ClassSessionDateSh);
                var address = $"{time.Year}/{time.Month}/{time.Day}/{_class.ClassTimeInformation}";
                resultFileProxy = _filesProxyAdapter.CreateDirectory(address);
            }

            return new ServiceResults<Guid>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = resultFileProxy,
                Result = model.ClassSessionId
            };
        }
        public IServiceResults<Guid> EditClassSession(ClassSession model)
        {
            _classSession.Attach(model);
            _uow.Entry(model).State = EntityState.Modified;
            var saveResult = _uow.SaveChanges();
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
                .Include(X => X.SessionMaterial)
                .OrderBy(X => X.ClassSessionDateMi)
                .AsNoTracking()
                .ToList();
        }
        public int GetSessionsCount(Guid classId)
        {
            return _classSession.Count(X => X.ClassId == classId && X.IsCanceled != false) * 2;
        }
        public IServiceResults<bool> SendNotification(Guid classId, string classSessionDateSh, bool isCanceled)
        {
            return _notificationService.Value.SendNotificationToClass(classId,
                  (isCanceled ? NotificationType.CanceledClass : NotificationType.AddSession),
                  PersianDateTime.Parse(classSessionDateSh).ToString(PersianDateTimeFormat.LongDate));
        }
        public IServiceResults<ClassSession> Find(Guid classSessionId)
        {
            var session = _classSession.Find(classSessionId);
            return new ServiceResults<ClassSession>
            {
                IsSuccessfull = session != null,
                Message = session != null ? string.Empty : BusinessMessage.RecordNotExist,
                Result = session
            };
        }
        public IServiceResults<bool> DeleteClassSession(Guid classSessionId)
        {
            var resultPaterial = _sessionMaterial.DeleteMaterial(classSessionId);
            if (!resultPaterial.IsSuccessfull)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.Error,
                    Result = false
                };
            }
            _classSession.Remove(_classSession.Find(classSessionId));
            var result = _uow.SaveChanges();
            return new ServiceResults<bool>
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result.ToBool()
            };
        }

        public IServiceResults<bool> SyncMaterial(Guid sessionId)
        {
            var session = Find(sessionId).Result;
            return SyncMaterial(session.ClassId, sessionId, session.ClassSessionDateSh);
        }
        public IServiceResults<bool> SyncMaterial(Guid classId, Guid classSessionId, string classSessionDateSh)
        {
            var _class = _classService.FindFullClassData(classId);
            var time = PersianDateTime.Parse(classSessionDateSh);
            var address = $"{time.Year}/{time.Month}/{time.Day}/{_class.ClassTimeInformation}";
            return _sessionMaterial.AddOrUpdateRange(classSessionId, address);
        }

        public string GetDirectoryAddress(Guid sessionId)
        {
            var session = Find(sessionId);
            var _class = _classService.FindFullClassData(session.Result.ClassId);
            var time = PersianDateTime.Parse(session.Result.ClassSessionDateSh);
            return $"{time.Year}/{time.Month}/{time.Day}/{_class.ClassTimeInformation}";
        }
    }
}

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
    using ExternalService.Interfaces;

    public class SessionMaterialService : ISessionMaterialService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<SessionMaterial> _sessionMaterial;
        readonly IFilesProxyAdapter _fileProxyAdapter;
        public SessionMaterialService(IUnitOfWork uow, IFilesProxyAdapter fileProxyAdapter)
        {
            _uow = uow;
            _sessionMaterial = uow.Set<SessionMaterial>();
            _fileProxyAdapter = fileProxyAdapter;
        }
        #endregion
        public IServiceResults<bool> AddOrUpdateRange(Guid sessionId, string address)
        {
            var model = _fileProxyAdapter.GetFilesAddress(address);
            var deleteResult = DeleteMaterial(sessionId);
            foreach (var item in model)
            {
                _sessionMaterial.Add(new SessionMaterial
                {
                    SessionMaterilId = Guid.NewGuid(),
                    ClassSessionId = sessionId,
                    DirectLink = item.DirectLink,
                    ExpireDate = DateTime.Now.AddDays(7),
                    Extension = item.Extension
                });
            }
            var saveResult = _uow.SaveChanges();
            return new ServiceResults<bool>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = saveResult.ToBool()
            };
        }

        public IEnumerable<SessionMaterial> GetAllSessionMaterial(Guid sessionId)
        {
            return _sessionMaterial.Where(X => X.ClassSessionId == sessionId).AsNoTracking().ToList();
        }
        public SessionMaterial Find(Guid sessionMaterialId)
        {
            return _sessionMaterial.Find(sessionMaterialId);
        }

        public IServiceResults<bool> DeleteMaterial(Guid sessionId)
        {
            foreach (var item in _sessionMaterial.Where(X => X.ClassSessionId == sessionId))
            {
                _sessionMaterial.Remove(item);
            }
            var saveResult = _uow.SaveChanges();
            return new ServiceResults<bool>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = saveResult.ToBool()
            };
        }
    }
}

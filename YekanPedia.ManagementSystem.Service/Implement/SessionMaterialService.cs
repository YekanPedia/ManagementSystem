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

    public class SessionMaterialService : ISessionMaterialService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<SessionMaterial> _sessionMaterial;
        public SessionMaterialService(IUnitOfWork uow)
        {
            _uow = uow;
            _sessionMaterial = uow.Set<SessionMaterial>();
        }
        #endregion
        public IServiceResults<bool> AddOrUpdateRange(List<SessionMaterial> model)
        {
            foreach (var item in model)
            {
                item.SessionMaterilId = Guid.NewGuid();
                _sessionMaterial.Add(item);
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
            return _sessionMaterial.Where(X => X.ClassSessionId == sessionId).ToList();
        }
        public SessionMaterial Find(Guid sessionMaterialId)
        {
            return _sessionMaterial.Find(sessionMaterialId);
        }
    }
}

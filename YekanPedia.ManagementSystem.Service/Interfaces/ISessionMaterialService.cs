namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Domain.Entity;
    using InfraStructure;

    public interface ISessionMaterialService
    {
        IEnumerable<SessionMaterial> GetAllSessionMaterial(Guid sessionId);
        IServiceResults<bool> AddOrUpdateRange(List<SessionMaterial> model);
        SessionMaterial Find(Guid sessionMaterialId);
    }
}

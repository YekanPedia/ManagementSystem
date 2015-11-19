namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Domain.Entity;
    using InfraStructure;

    public interface ISessionMaterialService
    {
        IEnumerable<SessionMaterial> GetAllSessionMaterial(Guid sessionId);
        IServiceResults<bool> AddOrUpdateRange(Guid sessionId, string address);
        SessionMaterial Find(Guid sessionMaterialId);
        IServiceResults<bool> DeleteMaterial(Guid sessionId);
    }
}

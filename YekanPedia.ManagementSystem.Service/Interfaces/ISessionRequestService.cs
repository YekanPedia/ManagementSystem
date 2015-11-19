namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Domain.Entity;
    using InfraStructure;

    public interface ISessionRequestService
    {
        IEnumerable<SessionRequest> GetAllSessionRequest(Guid sessionId);
        IServiceResults<Guid> Add(SessionRequest model);
        IServiceResults<bool> Remove(Guid sessionRequestId);
        SessionRequest Find(Guid sessionRequestId);
    }
}

namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using InfraStructure;
    using System.Collections.Generic;
    using Domain.Entity;

    public interface ISessionService
    {
        IServiceResults<Guid> EditClassSession(ClassSession model);
        IServiceResults<Guid> AddClassSession(ClassSession model);
        IServiceResults<bool> DeleteClassSession(Guid classSessionId);
        IEnumerable<ClassSession> GetSessions(Guid classId);
        IServiceResults<ClassSession> Find(Guid classSessionId);
        int GetSessionsCount(Guid classId);
        IServiceResults<bool> SendNotification(Guid classId, string  classSessionDateSh, bool isCanceled);
    }
}

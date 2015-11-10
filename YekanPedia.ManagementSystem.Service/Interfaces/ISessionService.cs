namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using InfraStructure;
    using System.Collections.Generic;
    using Domain.Entity;

    public interface ISessionService
    {
        IServiceResults<Guid> AddClassSession(ClassSession model);
        IEnumerable<ClassSession> GetSessions(Guid classId);
    }
}

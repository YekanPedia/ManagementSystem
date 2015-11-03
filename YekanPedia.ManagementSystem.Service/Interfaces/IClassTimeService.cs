namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using InfraStructure;
    using System.Collections.Generic;

    public interface IClassTimeService
    {
        IServiceResults<Guid> AddClassTime(ClassTime model);
        IEnumerable<ClassTime> GetClassTime(Guid classId);
    }
}

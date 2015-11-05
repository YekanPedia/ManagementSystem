namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using InfraStructure;
    using System.Collections.Generic;

    public interface IClassTimeService
    {
        IServiceResults<int> AddClassTime(ClassTime model);
        IServiceResults<bool> EditClassTime(ClassTime model);
        IEnumerable<ClassTime> GetClassTime(Guid classId);
        bool IsExist(ClassTime model);
    }
}

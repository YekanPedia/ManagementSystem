﻿namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using InfraStructure;
    using System.Collections.Generic;

    public interface IClassService
    {
        IServiceResults<Guid> AddClass(Class model);
        IServiceResults<bool> EditClass(Class model);
        Class FindClass(Guid classId);
        Class FindFullClassData(Guid classId);
        IEnumerable<Class> GetClass();
        IEnumerable<Class> GetExpiredClass();
        void FinishedClass(Guid classId);
    }
}

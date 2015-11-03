namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using InfraStructure;
    using System.Collections.Generic;

    public interface IClassService
    {
        IServiceResults<Guid> AddClass(Class model);
        IEnumerable<Class> GetClass();
    }
}

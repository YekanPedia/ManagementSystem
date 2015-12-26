namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using System.Collections.Generic;
    using InfraStructure;

    public interface IWorkService
    {
        IEnumerable<Work> GetWorks(Guid userId);
        IServiceResults<int> Add(Work model);
        Work Find(int workId);
        IServiceResults<bool> Remove(int workId);
        IServiceResults<bool> ChangePublicState(int workId);
    }
}

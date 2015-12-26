namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using System.Collections.Generic;
    using InfraStructure;

    public interface IEducationService
    {
        IEnumerable<Education> GetEducations(Guid userId);
        Education Find(int educationId);
        IServiceResults<int> Add(Education model);
        IServiceResults<bool> Remove(int educationId);
        IServiceResults<bool> ChangePublicState(int educationId);
    }
}

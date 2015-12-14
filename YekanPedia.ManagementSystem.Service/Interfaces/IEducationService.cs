namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using System.Collections.Generic;
    using InfraStructure;

    public interface IEducationService
    {
        IEnumerable<Education> GetEducations(Guid userId);
        IServiceResults<int> Add(Education model);
    }
}

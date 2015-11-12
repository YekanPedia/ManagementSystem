namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using InfraStructure;
    using Domain.Entity;

    public interface IFeedbackService
    {
        IServiceResults<Guid> Add(Feedback model);
    }
}

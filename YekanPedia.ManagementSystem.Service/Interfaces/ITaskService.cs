namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Domain.Entity;

    public interface ITaskService
    {
        IEnumerable<Tasks> GetUserTask(Guid userId);
        void AddUserTask(Tasks model);
        void EditUserTaskProgress(Tasks model);
    }
}

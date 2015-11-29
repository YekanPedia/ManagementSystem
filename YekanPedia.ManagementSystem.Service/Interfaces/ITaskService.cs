namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Domain.Entity;
    using InfraStructure;

    public interface ITaskService
    {
        IEnumerable<Tasks> GetUserTask(Guid userId);
        IServiceResults<int> AddUserTask(Tasks model);
        IServiceResults<int> AddClassTask(Guid classId, string subject);
        void EditUserTaskProgress(Guid userId, TaskType type, int value);
        IServiceResults<bool> Done(int taskId);
    }
}

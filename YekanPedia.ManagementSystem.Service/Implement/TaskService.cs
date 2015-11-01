namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;

    public class TaskService : ITaskService
    {
        #region Constructur
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<Tasks> _task;
        public TaskService(IUnitOfWork uow)
        {
            _uow = uow;
            _task = uow.Set<Tasks>();
        }


        #endregion
        public void AddUserTask(Tasks model)
        {
            _task.Add(model);
            _uow.SaveChanges();
        }

        public void EditUserTaskProgress(Guid userId, TaskType type, int value)
        {
            Tasks task = _task.FirstOrDefault(X => X.UserId == userId && X.Type == type && X.Progress < 100);
            if (task != null)
            {
                task.Progress += value;
                _uow.SaveChanges();
            }
        }

        public IEnumerable<Tasks> GetUserTask(Guid userId)
        {
            return _task.Where(X => X.UserId == userId && X.Progress < 100).ToList();
        }
    }
}

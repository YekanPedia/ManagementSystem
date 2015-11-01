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

        public void EditUserTaskProgress(Tasks model)
        {
            _task.Attach(model);
            _uow.SaveChanges();
        }

        public IEnumerable<Tasks> GetUserTask(Guid userId)
        {
            return _task.Where(X => X.UserId == userId).ToList();
        }
    }
}

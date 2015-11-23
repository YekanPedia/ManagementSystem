namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;
    using InfraStructure;
    using Properties;

    public class TaskService : ITaskService
    {
        #region Constructur
        readonly IUnitOfWork _uow;
        readonly IDbSet<Tasks> _task;
        readonly IUserService _userService;
        public TaskService(IUnitOfWork uow, IUserService userService)
        {
            _userService = userService;
            _uow = uow;
            _task = uow.Set<Tasks>();
        }
        #endregion
        public IServiceResults<int> AddUserTask(Tasks model)
        {
            _task.Add(model);
            var saveResult = _uow.SaveChanges();
            return new ServiceResults<int>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = model.TaskId
            };
        }
        public IServiceResults<int> AddClassTask(Guid classId, string subject)
        {
            foreach (var item in _userService.GetUsers(null, classId).Result)
            {
                _task.Add(new Tasks
                {
                    IsFinishable = true,
                    Link = string.Empty,
                    Progress = 0,
                    ProgressbarType = ProgressbarType.Info,
                    Subject = subject,
                    Type = TaskType.Profile,
                    UserId = item.UserId,
                    FinishDateMi = DateTime.Now.AddDays(7)
                });
            }
            var saveResult = _uow.SaveChanges();
            return new ServiceResults<int>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = 1
            };
        }

        public void EditUserTaskProgress(Guid userId, TaskType type, int value)
        {
            Tasks task = _task.FirstOrDefault(X => X.UserId == userId && X.Type == type);
            if (task != null)
            {
                task.Progress = value;
                _uow.SaveChanges();
            }
        }
        public IEnumerable<Tasks> GetUserTask(Guid userId)
        {
            return _task.Where(X => X.UserId == userId && X.Progress < 100 && X.FinishDateMi > DateTime.Now).AsNoTracking().ToList();
        }
    }
}

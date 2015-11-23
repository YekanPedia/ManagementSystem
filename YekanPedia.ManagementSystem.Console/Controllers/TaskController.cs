namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using Extensions.Authentication;
    using System;
    using Domain.Entity;

    public partial class TaskController : Controller
    {
        #region Constructure
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        #endregion
        [ChildActionOnly]
        public virtual PartialViewResult GetAllTasks()
        {
            return PartialView(MVC.Task.Views.Partial._Task, _taskService.GetUserTask((User as ICurrentUserPrincipal).UserId));
        }

        [HttpPost]
        public virtual JsonResult AddTaskToUser(Guid userId, string message)
        {
            return Json(_taskService.AddUserTask(new Tasks
            {
                IsFinishable = true,
                Link = string.Empty,
                Progress = 0,
                ProgressbarType = ProgressbarType.Info,
                Subject = message,
                Type = TaskType.Profile,
                UserId = userId,
                FinishDateMi = DateTime.Now.AddDays(7)
            }));
        }

        [HttpPost]
        public virtual JsonResult AddTaskToClass(Guid classId, string message)
        {
            return Json(_taskService.AddClassTask(classId, message));
        }
    }
}
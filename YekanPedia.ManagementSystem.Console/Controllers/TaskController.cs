namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using InfraStructure.Extension.Authentication;
    using System;
    using Domain.Entity;
    using System.Collections.Generic;
    using Resources;
    using System.Linq;

    public partial class TaskController : Controller
    {
        #region Constructure
        readonly ITaskService _taskService;
        readonly IClassService _classService;
        public TaskController(ITaskService taskService, IClassService classService)
        {
            _classService = classService;
            _taskService = taskService;
        }
        #endregion
        [ChildActionOnly]
        public virtual PartialViewResult GetAllTasks()
        {
            return PartialView(MVC.Task.Views.Partial._Task, _taskService.GetUserTask((User as ICurrentUserPrincipal).UserId));
        }

        [ChildActionOnly]
        public virtual PartialViewResult GetAllTasksWidget()
        {
            ViewBag.Class = new List<SelectListItem>();
            ((List<SelectListItem>)(ViewBag.Class)).Add(new SelectListItem { Text = LocalMessage.EmptySelect, Value = string.Empty });
            ((List<SelectListItem>)(ViewBag.Class)).AddRange(_classService.GetClass().Select(x => new SelectListItem
            {
                Text = x.ClassInformaion,
                Value = x.ClassId.ToString()
            }).ToList());
            return PartialView(MVC.Task.Views.Partial._TaskWidget, _taskService.GetUserTask((User as ICurrentUserPrincipal).UserId));
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
        [HttpPost]
        public virtual JsonResult Done(int taskId)
        {
            return Json(_taskService.Done(taskId));
        }
    }
}
namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using Extensions.Authentication;

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
    }
}
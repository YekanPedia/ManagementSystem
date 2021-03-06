// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace YekanPedia.ManagementSystem.Console.Controllers
{
    public partial class TaskController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected TaskController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult AddTaskToUser()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.AddTaskToUser);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult AddTaskToClass()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.AddTaskToClass);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult Done()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Done);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public TaskController Actions { get { return MVC.Task; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Task";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Task";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string GetAllTasks = "GetAllTasks";
            public readonly string GetAllTasksWidget = "GetAllTasksWidget";
            public readonly string AddTaskToUser = "AddTaskToUser";
            public readonly string AddTaskToClass = "AddTaskToClass";
            public readonly string Done = "Done";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string GetAllTasks = "GetAllTasks";
            public const string GetAllTasksWidget = "GetAllTasksWidget";
            public const string AddTaskToUser = "AddTaskToUser";
            public const string AddTaskToClass = "AddTaskToClass";
            public const string Done = "Done";
        }


        static readonly ActionParamsClass_AddTaskToUser s_params_AddTaskToUser = new ActionParamsClass_AddTaskToUser();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddTaskToUser AddTaskToUserParams { get { return s_params_AddTaskToUser; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddTaskToUser
        {
            public readonly string userId = "userId";
            public readonly string message = "message";
        }
        static readonly ActionParamsClass_AddTaskToClass s_params_AddTaskToClass = new ActionParamsClass_AddTaskToClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddTaskToClass AddTaskToClassParams { get { return s_params_AddTaskToClass; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddTaskToClass
        {
            public readonly string classId = "classId";
            public readonly string message = "message";
        }
        static readonly ActionParamsClass_Done s_params_Done = new ActionParamsClass_Done();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Done DoneParams { get { return s_params_Done; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Done
        {
            public readonly string taskId = "taskId";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
            }
            static readonly _PartialClass s_Partial = new _PartialClass();
            public _PartialClass Partial { get { return s_Partial; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _PartialClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string _Create = "_Create";
                    public readonly string _Task = "_Task";
                    public readonly string _TaskWidget = "_TaskWidget";
                }
                public readonly string _Create = "~/Views/Task/Partial/_Create.cshtml";
                public readonly string _Task = "~/Views/Task/Partial/_Task.cshtml";
                public readonly string _TaskWidget = "~/Views/Task/Partial/_TaskWidget.cshtml";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_TaskController : YekanPedia.ManagementSystem.Console.Controllers.TaskController
    {
        public T4MVC_TaskController() : base(Dummy.Instance) { }

        [NonAction]
        partial void GetAllTasksOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult GetAllTasks()
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetAllTasks);
            GetAllTasksOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void GetAllTasksWidgetOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult GetAllTasksWidget()
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetAllTasksWidget);
            GetAllTasksWidgetOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddTaskToUserOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid userId, string message);

        [NonAction]
        public override System.Web.Mvc.JsonResult AddTaskToUser(System.Guid userId, string message)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.AddTaskToUser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "userId", userId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "message", message);
            AddTaskToUserOverride(callInfo, userId, message);
            return callInfo;
        }

        [NonAction]
        partial void AddTaskToClassOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid classId, string message);

        [NonAction]
        public override System.Web.Mvc.JsonResult AddTaskToClass(System.Guid classId, string message)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.AddTaskToClass);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "classId", classId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "message", message);
            AddTaskToClassOverride(callInfo, classId, message);
            return callInfo;
        }

        [NonAction]
        partial void DoneOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int taskId);

        [NonAction]
        public override System.Web.Mvc.JsonResult Done(int taskId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Done);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "taskId", taskId);
            DoneOverride(callInfo, taskId);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114

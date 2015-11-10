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
    public partial class UserController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected UserController(Dummy d) { }

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
        public virtual System.Web.Mvc.PartialViewResult Search()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Search);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult ChangeState()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.ChangeState);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public UserController Actions { get { return MVC.User; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "User";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "User";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Search = "Search";
            public readonly string Manage = "Manage";
            public readonly string ChangeState = "ChangeState";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Search = "Search";
            public const string Manage = "Manage";
            public const string ChangeState = "ChangeState";
        }


        static readonly ActionParamsClass_Search s_params_Search = new ActionParamsClass_Search();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Search SearchParams { get { return s_params_Search; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Search
        {
            public readonly string model = "model";
            public readonly string classId = "classId";
        }
        static readonly ActionParamsClass_ChangeState s_params_ChangeState = new ActionParamsClass_ChangeState();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ChangeState ChangeStateParams { get { return s_params_ChangeState; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ChangeState
        {
            public readonly string userId = "userId";
            public readonly string status = "status";
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
                public readonly string Manage = "Manage";
            }
            public readonly string Manage = "~/Views/User/Manage.cshtml";
            static readonly _PartialClass s_Partial = new _PartialClass();
            public _PartialClass Partial { get { return s_Partial; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _PartialClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string _HeaderUserGrid = "_HeaderUserGrid";
                    public readonly string _List = "_List";
                    public readonly string _SearchBox = "_SearchBox";
                }
                public readonly string _HeaderUserGrid = "~/Views/User/Partial/_HeaderUserGrid.cshtml";
                public readonly string _List = "~/Views/User/Partial/_List.cshtml";
                public readonly string _SearchBox = "~/Views/User/Partial/_SearchBox.cshtml";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_UserController : YekanPedia.ManagementSystem.Console.Controllers.UserController
    {
        public T4MVC_UserController() : base(Dummy.Instance) { }

        [NonAction]
        partial void SearchOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, YekanPedia.ManagementSystem.Domain.Entity.User model, System.Guid? classId);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult Search(YekanPedia.ManagementSystem.Domain.Entity.User model, System.Guid? classId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Search);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "classId", classId);
            SearchOverride(callInfo, model, classId);
            return callInfo;
        }

        [NonAction]
        partial void ManageOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult Manage()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.Manage);
            ManageOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ChangeStateOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid userId, bool status);

        [NonAction]
        public override System.Web.Mvc.JsonResult ChangeState(System.Guid userId, bool status)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.ChangeState);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "userId", userId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "status", status);
            ChangeStateOverride(callInfo, userId, status);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114

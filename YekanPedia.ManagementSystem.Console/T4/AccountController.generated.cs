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
    public partial class AccountController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AccountController(Dummy d) { }

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
        public virtual System.Web.Mvc.JsonResult Register()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Register);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Profile()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Profile);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult EditAboutMe()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.EditAboutMe);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult EditBasicInfo()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.EditBasicInfo);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult EditCallInfo()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.EditCallInfo);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult EmailChecker()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.EmailChecker);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AccountController Actions { get { return MVC.Account; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Account";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Account";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Register = "Register";
            public readonly string Profile = "Profile";
            public readonly string EditAboutMe = "EditAboutMe";
            public readonly string EditBasicInfo = "EditBasicInfo";
            public readonly string EditCallInfo = "EditCallInfo";
            public readonly string EmailChecker = "EmailChecker";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Register = "Register";
            public const string Profile = "Profile";
            public const string EditAboutMe = "EditAboutMe";
            public const string EditBasicInfo = "EditBasicInfo";
            public const string EditCallInfo = "EditCallInfo";
            public const string EmailChecker = "EmailChecker";
        }


        static readonly ActionParamsClass_Register s_params_Register = new ActionParamsClass_Register();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Register RegisterParams { get { return s_params_Register; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Register
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_Profile s_params_Profile = new ActionParamsClass_Profile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Profile ProfileParams { get { return s_params_Profile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Profile
        {
            public readonly string userId = "userId";
        }
        static readonly ActionParamsClass_EditAboutMe s_params_EditAboutMe = new ActionParamsClass_EditAboutMe();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditAboutMe EditAboutMeParams { get { return s_params_EditAboutMe; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditAboutMe
        {
            public readonly string UserId = "UserId";
            public readonly string AboutMe = "AboutMe";
        }
        static readonly ActionParamsClass_EditBasicInfo s_params_EditBasicInfo = new ActionParamsClass_EditBasicInfo();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditBasicInfo EditBasicInfoParams { get { return s_params_EditBasicInfo; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditBasicInfo
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_EditCallInfo s_params_EditCallInfo = new ActionParamsClass_EditCallInfo();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditCallInfo EditCallInfoParams { get { return s_params_EditCallInfo; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditCallInfo
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_EmailChecker s_params_EmailChecker = new ActionParamsClass_EmailChecker();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EmailChecker EmailCheckerParams { get { return s_params_EmailChecker; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EmailChecker
        {
            public readonly string email = "email";
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
                public readonly string Profile = "Profile";
            }
            public readonly string Profile = "~/Views/Account/Profile.cshtml";
            static readonly _PartialClass s_Partial = new _PartialClass();
            public _PartialClass Partial { get { return s_Partial; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _PartialClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string _Register = "_Register";
                    public readonly string _RegisterationComplete = "_RegisterationComplete";
                    public readonly string _TimeLine = "_TimeLine";
                }
                public readonly string _Register = "~/Views/Account/Partial/_Register.cshtml";
                public readonly string _RegisterationComplete = "~/Views/Account/Partial/_RegisterationComplete.cshtml";
                public readonly string _TimeLine = "~/Views/Account/Partial/_TimeLine.cshtml";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AccountController : YekanPedia.ManagementSystem.Console.Controllers.AccountController
    {
        public T4MVC_AccountController() : base(Dummy.Instance) { }

        [NonAction]
        partial void RegisterOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, YekanPedia.ManagementSystem.Domain.Entity.User model);

        [NonAction]
        public override System.Web.Mvc.JsonResult Register(YekanPedia.ManagementSystem.Domain.Entity.User model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Register);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            RegisterOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void ProfileOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.Guid userId);

        [NonAction]
        public override System.Web.Mvc.ActionResult Profile(System.Guid userId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Profile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "userId", userId);
            ProfileOverride(callInfo, userId);
            return callInfo;
        }

        [NonAction]
        partial void EditAboutMeOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, System.Guid UserId, string AboutMe);

        [NonAction]
        public override System.Web.Mvc.JsonResult EditAboutMe(System.Guid UserId, string AboutMe)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.EditAboutMe);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "UserId", UserId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "AboutMe", AboutMe);
            EditAboutMeOverride(callInfo, UserId, AboutMe);
            return callInfo;
        }

        [NonAction]
        partial void EditBasicInfoOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, YekanPedia.ManagementSystem.Domain.Entity.User model);

        [NonAction]
        public override System.Web.Mvc.JsonResult EditBasicInfo(YekanPedia.ManagementSystem.Domain.Entity.User model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.EditBasicInfo);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            EditBasicInfoOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void EditCallInfoOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, YekanPedia.ManagementSystem.Domain.Entity.User model);

        [NonAction]
        public override System.Web.Mvc.JsonResult EditCallInfo(YekanPedia.ManagementSystem.Domain.Entity.User model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.EditCallInfo);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            EditCallInfoOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void EmailCheckerOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string email);

        [NonAction]
        public override System.Web.Mvc.JsonResult EmailChecker(string email)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.EmailChecker);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "email", email);
            EmailCheckerOverride(callInfo, email);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114

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
    public partial class SkillsController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected SkillsController(Dummy d) { }

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
        public virtual System.Web.Mvc.PartialViewResult GetSkillss()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetSkillss);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult AddSkills()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.AddSkills);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult ChangePublicState()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.ChangePublicState);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult Remove()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Remove);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public SkillsController Actions { get { return MVC.Skills; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Skills";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Skills";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string GetSkillss = "GetSkillss";
            public readonly string AddSkills = "AddSkills";
            public readonly string ChangePublicState = "ChangePublicState";
            public readonly string Remove = "Remove";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string GetSkillss = "GetSkillss";
            public const string AddSkills = "AddSkills";
            public const string ChangePublicState = "ChangePublicState";
            public const string Remove = "Remove";
        }


        static readonly ActionParamsClass_GetSkillss s_params_GetSkillss = new ActionParamsClass_GetSkillss();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetSkillss GetSkillssParams { get { return s_params_GetSkillss; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetSkillss
        {
            public readonly string userId = "userId";
        }
        static readonly ActionParamsClass_AddSkills s_params_AddSkills = new ActionParamsClass_AddSkills();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddSkills AddSkillsParams { get { return s_params_AddSkills; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddSkills
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ChangePublicState s_params_ChangePublicState = new ActionParamsClass_ChangePublicState();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ChangePublicState ChangePublicStateParams { get { return s_params_ChangePublicState; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ChangePublicState
        {
            public readonly string skillsId = "skillsId";
        }
        static readonly ActionParamsClass_Remove s_params_Remove = new ActionParamsClass_Remove();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Remove RemoveParams { get { return s_params_Remove; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Remove
        {
            public readonly string skillsId = "skillsId";
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
                    public readonly string _SkillCreate = "_SkillCreate";
                    public readonly string _Skills = "_Skills";
                }
                public readonly string _SkillCreate = "~/Views/Skills/Partial/_SkillCreate.cshtml";
                public readonly string _Skills = "~/Views/Skills/Partial/_Skills.cshtml";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_SkillsController : YekanPedia.ManagementSystem.Console.Controllers.SkillsController
    {
        public T4MVC_SkillsController() : base(Dummy.Instance) { }

        [NonAction]
        partial void GetSkillssOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, System.Guid userId);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult GetSkillss(System.Guid userId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetSkillss);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "userId", userId);
            GetSkillssOverride(callInfo, userId);
            return callInfo;
        }

        [NonAction]
        partial void AddSkillsOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, YekanPedia.ManagementSystem.Domain.Entity.Skills model);

        [NonAction]
        public override System.Web.Mvc.JsonResult AddSkills(YekanPedia.ManagementSystem.Domain.Entity.Skills model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.AddSkills);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            AddSkillsOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void ChangePublicStateOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int skillsId);

        [NonAction]
        public override System.Web.Mvc.JsonResult ChangePublicState(int skillsId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.ChangePublicState);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "skillsId", skillsId);
            ChangePublicStateOverride(callInfo, skillsId);
            return callInfo;
        }

        [NonAction]
        partial void RemoveOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int skillsId);

        [NonAction]
        public override System.Web.Mvc.JsonResult Remove(int skillsId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Remove);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "skillsId", skillsId);
            RemoveOverride(callInfo, skillsId);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114

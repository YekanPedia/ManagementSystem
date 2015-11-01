﻿// <auto-generated />
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

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    public static YekanPedia.ManagementSystem.Console.Controllers.AccountController Account = new YekanPedia.ManagementSystem.Console.Controllers.T4MVC_AccountController();
    public static YekanPedia.ManagementSystem.Console.Controllers.DashboardController Dashboard = new YekanPedia.ManagementSystem.Console.Controllers.T4MVC_DashboardController();
    public static YekanPedia.ManagementSystem.Console.Controllers.OAuthController OAuth = new YekanPedia.ManagementSystem.Console.Controllers.T4MVC_OAuthController();
    public static YekanPedia.ManagementSystem.Console.Controllers.TaskController Task = new YekanPedia.ManagementSystem.Console.Controllers.T4MVC_TaskController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}

namespace T4MVC
{
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_JsonResult : System.Web.Mvc.JsonResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_JsonResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ViewResult : System.Web.Mvc.ViewResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ViewResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_PartialViewResult : System.Web.Mvc.PartialViewResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_PartialViewResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_RedirectToRouteResult : System.Web.Mvc.RedirectToRouteResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_RedirectToRouteResult(string area, string controller, string action, string protocol = null): base(default(System.Web.Routing.RouteValueDictionary))
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Scripts {
        private const string URLPATH = "~/Scripts";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Application {
            private const string URLPATH = "~/Scripts/Application";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string AccountController_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/AccountController.min.js") ? Url("AccountController.min.js") : Url("AccountController.js");
            public static readonly string OAuthController_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/OAuthController.min.js") ? Url("OAuthController.min.js") : Url("OAuthController.js");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Bootstrap {
            private const string URLPATH = "~/Scripts/Bootstrap";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string bootstrap_min_js = Url("bootstrap.min.js");
        }
    
        public static readonly string functions_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/functions.min.js") ? Url("functions.min.js") : Url("functions.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class JQuery {
            private const string URLPATH = "~/Scripts/JQuery";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Ajax {
                private const string URLPATH = "~/Scripts/JQuery/Ajax";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string jquery_unobtrusive_ajax_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.unobtrusive-ajax.min.js") ? Url("jquery.unobtrusive-ajax.min.js") : Url("jquery.unobtrusive-ajax.js");
            }
        
            public static readonly string jquery_1_10_2_min_js = Url("jquery-1.10.2.min.js");
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class LightGallery {
                private const string URLPATH = "~/Scripts/JQuery/LightGallery";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string lightGallery_min_js = Url("lightGallery.min.js");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Loadingbar {
                private const string URLPATH = "~/Scripts/JQuery/Loadingbar";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string Loadingbar_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/Loadingbar.min.js") ? Url("Loadingbar.min.js") : Url("Loadingbar.js");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class NiceScroll {
                private const string URLPATH = "~/Scripts/JQuery/NiceScroll";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string jquery_nicescroll_min_js = Url("jquery.nicescroll.min.js");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class PasswordStrongly {
                private const string URLPATH = "~/Scripts/JQuery/PasswordStrongly";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string PasswordStrongly_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/PasswordStrongly.min.js") ? Url("PasswordStrongly.min.js") : Url("PasswordStrongly.js");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Phoenix {
                private const string URLPATH = "~/Scripts/JQuery/Phoenix";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string Phoenix_core_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/Phoenix.core.min.js") ? Url("Phoenix.core.min.js") : Url("Phoenix.core.js");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Sweet {
                private const string URLPATH = "~/Scripts/JQuery/Sweet";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string sweet_alert_min_js = Url("sweet-alert.min.js");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Type {
                private const string URLPATH = "~/Scripts/JQuery/Type";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string jQuery_Type_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jQuery.Type.min.js") ? Url("jQuery.Type.min.js") : Url("jQuery.Type.js");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Validation {
                private const string URLPATH = "~/Scripts/JQuery/Validation";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string jquery_validate_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate.min.js") ? Url("jquery.validate.min.js") : Url("jquery.validate.js");
                public static readonly string jquery_validate_unobtrusive_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validate.unobtrusive.min.js") ? Url("jquery.validate.unobtrusive.min.js") : Url("jquery.validate.unobtrusive.js");
                public static readonly string jquery_validation_messages_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/jquery.validation.messages.min.js") ? Url("jquery.validation.messages.min.js") : Url("jquery.validation.messages.js");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Wave {
                private const string URLPATH = "~/Scripts/JQuery/Wave";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string waves_min_js = Url("waves.min.js");
            }
        
        }
    
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Content {
        private const string URLPATH = "~/Content";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Images {
            private const string URLPATH = "~/Content/Images";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Avatar {
                private const string URLPATH = "~/Content/Images/Avatar";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string _1_png = Url("1.png");
                public static readonly string _10_png = Url("10.png");
                public static readonly string _11_png = Url("11.png");
                public static readonly string _2_png = Url("2.png");
                public static readonly string _3_png = Url("3.png");
                public static readonly string _4_png = Url("4.png");
                public static readonly string _5_png = Url("5.png");
                public static readonly string _6_png = Url("6.png");
                public static readonly string _7_png = Url("7.png");
                public static readonly string _8_png = Url("8.png");
                public static readonly string _9_png = Url("9.png");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Background {
                private const string URLPATH = "~/Content/Images/Background";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string profile_menu_png = Url("profile-menu.png");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Icon {
                private const string URLPATH = "~/Content/Images/Icon";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string notifications_png = Url("notifications.png");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Logo {
                private const string URLPATH = "~/Content/Images/Logo";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string Logo_png = Url("Logo.png");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Menu {
                private const string URLPATH = "~/Content/Images/Menu";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string ellipsis_png = Url("ellipsis.png");
                public static readonly string ellipsis_2x_png = Url("ellipsis@2x.png");
                public static readonly string menu_2_rtl_png = Url("menu-2-rtl.png");
                public static readonly string menu_2_png = Url("menu-2.png");
                public static readonly string menu_2_2x_rtl_png = Url("menu-2@2x-rtl.png");
                public static readonly string menu_2_2x_png = Url("menu-2@2x.png");
                public static readonly string message_png = Url("message.png");
                public static readonly string message_2x_png = Url("message@2x.png");
                public static readonly string notification_png = Url("notification.png");
                public static readonly string notification_2x_png = Url("notification@2x.png");
                public static readonly string search_png = Url("search.png");
                public static readonly string search_2x_png = Url("search@2x.png");
                public static readonly string task_png = Url("task.png");
                public static readonly string task_2x_png = Url("task@2x.png");
            }
        
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Styles {
            private const string URLPATH = "~/Content/Styles";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Ltr {
                private const string URLPATH = "~/Content/Styles/Ltr";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string AppStyle1_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/AppStyle1.min.css") ? Url("AppStyle1.min.css") : Url("AppStyle1.css");
                     
                public static readonly string AppStyle2_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/AppStyle2.min.css") ? Url("AppStyle2.min.css") : Url("AppStyle2.css");
                     
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Public {
                private const string URLPATH = "~/Content/Styles/Public";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string Animate_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/Animate.min.css") ? Url("Animate.min.css") : Url("Animate.css");
                     
                public static readonly string LightGallery_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/LightGallery.min.css") ? Url("LightGallery.min.css") : Url("LightGallery.css");
                     
                public static readonly string LoadingBar_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/LoadingBar.min.css") ? Url("LoadingBar.min.css") : Url("LoadingBar.css");
                     
                public static readonly string MaterialDesignIconicFont_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/MaterialDesignIconicFont.min.css") ? Url("MaterialDesignIconicFont.min.css") : Url("MaterialDesignIconicFont.css");
                     
                public static readonly string Sweet_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/Sweet.min.css") ? Url("Sweet.min.css") : Url("Sweet.css");
                     
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class Rtl {
                private const string URLPATH = "~/Content/Styles/Rtl";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string AppStyle1_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/AppStyle1.min.css") ? Url("AppStyle1.min.css") : Url("AppStyle1.css");
                     
            }
        
        }
    
    }

    
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        public static partial class Scripts 
        {
            public static partial class Application 
            {
                public static class Assets
                {
                    public const string AccountController_js = "~/Scripts/Application/AccountController.js"; 
                    public const string OAuthController_js = "~/Scripts/Application/OAuthController.js"; 
                }
            }
            public static partial class Bootstrap 
            {
                public static class Assets
                {
                    public const string bootstrap_min_js = "~/Scripts/Bootstrap/bootstrap.min.js"; 
                }
            }
            public static partial class JQuery 
            {
                public static partial class Ajax 
                {
                    public static class Assets
                    {
                        public const string jquery_unobtrusive_ajax_js = "~/Scripts/JQuery/Ajax/jquery.unobtrusive-ajax.js"; 
                    }
                }
                public static partial class LightGallery 
                {
                    public static class Assets
                    {
                        public const string lightGallery_min_js = "~/Scripts/JQuery/LightGallery/lightGallery.min.js"; 
                    }
                }
                public static partial class Loadingbar 
                {
                    public static class Assets
                    {
                        public const string Loadingbar_js = "~/Scripts/JQuery/Loadingbar/Loadingbar.js"; 
                    }
                }
                public static partial class NiceScroll 
                {
                    public static class Assets
                    {
                        public const string jquery_nicescroll_min_js = "~/Scripts/JQuery/NiceScroll/jquery.nicescroll.min.js"; 
                    }
                }
                public static partial class PasswordStrongly 
                {
                    public static class Assets
                    {
                        public const string PasswordStrongly_js = "~/Scripts/JQuery/PasswordStrongly/PasswordStrongly.js"; 
                    }
                }
                public static partial class Phoenix 
                {
                    public static class Assets
                    {
                        public const string Phoenix_core_js = "~/Scripts/JQuery/Phoenix/Phoenix.core.js"; 
                    }
                }
                public static partial class Sweet 
                {
                    public static class Assets
                    {
                        public const string sweet_alert_min_js = "~/Scripts/JQuery/Sweet/sweet-alert.min.js"; 
                    }
                }
                public static partial class Type 
                {
                    public static class Assets
                    {
                        public const string jQuery_Type_js = "~/Scripts/JQuery/Type/jQuery.Type.js"; 
                    }
                }
                public static partial class Validation 
                {
                    public static class Assets
                    {
                        public const string jquery_validate_js = "~/Scripts/JQuery/Validation/jquery.validate.js"; 
                        public const string jquery_validate_unobtrusive_js = "~/Scripts/JQuery/Validation/jquery.validate.unobtrusive.js"; 
                        public const string jquery_validation_messages_js = "~/Scripts/JQuery/Validation/jquery.validation.messages.js"; 
                    }
                }
                public static partial class Wave 
                {
                    public static class Assets
                    {
                        public const string waves_min_js = "~/Scripts/JQuery/Wave/waves.min.js"; 
                    }
                }
                public static class Assets
                {
                    public const string jquery_1_10_2_min_js = "~/Scripts/JQuery/jquery-1.10.2.min.js"; 
                }
            }
            public static class Assets
            {
                public const string functions_js = "~/Scripts/functions.js"; 
            }
        }
        public static partial class Content 
        {
            public static partial class Images 
            {
                public static partial class Avatar 
                {
                    public static class Assets
                    {
                    }
                }
                public static partial class Background 
                {
                    public static class Assets
                    {
                    }
                }
                public static partial class Icon 
                {
                    public static class Assets
                    {
                    }
                }
                public static partial class Logo 
                {
                    public static class Assets
                    {
                    }
                }
                public static partial class Menu 
                {
                    public static class Assets
                    {
                    }
                }
                public static class Assets
                {
                }
            }
            public static partial class Styles 
            {
                public static partial class Ltr 
                {
                    public static class Assets
                    {
                        public const string AppStyle1_css = "~/Content/Styles/Ltr/AppStyle1.css";
                        public const string AppStyle2_css = "~/Content/Styles/Ltr/AppStyle2.css";
                    }
                }
                public static partial class Public 
                {
                    public static class Assets
                    {
                        public const string Animate_css = "~/Content/Styles/Public/Animate.css";
                        public const string LightGallery_css = "~/Content/Styles/Public/LightGallery.css";
                        public const string LoadingBar_css = "~/Content/Styles/Public/LoadingBar.css";
                        public const string MaterialDesignIconicFont_css = "~/Content/Styles/Public/MaterialDesignIconicFont.css";
                        public const string Sweet_css = "~/Content/Styles/Public/Sweet.css";
                    }
                }
                public static partial class Rtl 
                {
                    public static class Assets
                    {
                        public const string AppStyle1_css = "~/Content/Styles/Rtl/AppStyle1.css";
                    }
                }
                public static class Assets
                {
                }
            }
            public static class Assets
            {
            }
        }
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114



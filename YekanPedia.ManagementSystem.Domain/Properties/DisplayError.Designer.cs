﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YekanPedia.ManagementSystem.Domain.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class DisplayError {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DisplayError() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("YekanPedia.ManagementSystem.Domain.Properties.DisplayError", typeof(DisplayError).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to لطفا پست الکترونیک را به طور صحیح وارد نمایید.
        /// </summary>
        public static string Email {
            get {
                return ResourceManager.GetString("Email", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to لطفا فقط عدد وارد نمایید.
        /// </summary>
        public static string Int {
            get {
                return ResourceManager.GetString("Int", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to لطفا بیشتر از {1} کاراکتر وارد ننمایید.
        /// </summary>
        public static string MaxLength {
            get {
                return ResourceManager.GetString("MaxLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to لطفا کمتر از {1} کاراکتر وارد ننمایید.
        /// </summary>
        public static string MinLength {
            get {
                return ResourceManager.GetString("MinLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to لطفا شماره همراه را صحیح وارد نمایید.
        /// </summary>
        public static string MobileError {
            get {
                return ResourceManager.GetString("MobileError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to لطفا تاریخ با به صورت YYYY/MM/DD  وارد نمایید.
        /// </summary>
        public static string PersianDate {
            get {
                return ResourceManager.GetString("PersianDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to این فیلد اجباری می باشد.
        /// </summary>
        public static string Required {
            get {
                return ResourceManager.GetString("Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to لطفا زمان با به صورت HH:MM  وارد نمایید.
        /// </summary>
        public static string Time {
            get {
                return ResourceManager.GetString("Time", resourceCulture);
            }
        }
    }
}

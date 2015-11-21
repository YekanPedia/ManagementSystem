namespace YekanPedia.ManagementSystem.Console
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;

    /// <summary>
    /// کلاسی برای دریافت خطاهای صورت گرفته در درخواست های آجاکسی 
    /// </summary>
    public static class ErrorModelStateController
    {
        /// <summary>
        /// دریافت خطاهای صورت گرفته
        /// </summary>
        /// <param name="ControllerIns">کنترلر مربوطه</param>
        /// <returns>لیست خطاها با ذکر نام فیلد</returns>
        public static string GetErrorsModelState(this Controller ControllerIns)
        {
            var errors = new Dictionary<string, object>();
            foreach (var key in ControllerIns.ModelState.Keys)
            {
                if (ControllerIns.ModelState[key].Errors.Count > 0)
                {
                    errors[key] = ControllerIns.ModelState[key].Errors;
                }
            }
            return new JavaScriptSerializer().Serialize(errors);
        }
    }
}

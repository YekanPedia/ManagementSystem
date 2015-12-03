namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System;
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;

    public partial class SettingController : Controller
    {
        #region Constructure
        readonly ISettingService _settingService;
        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        #endregion
        [HttpGet]
        public virtual ViewResult Manage()
        {
            return View(_settingService.GetDefaultSetting());
        }

        [HttpPost]
        public virtual JsonResult Edit(Setting model)
        {
            return Json(_settingService.Edit(model));
        }
    }
}
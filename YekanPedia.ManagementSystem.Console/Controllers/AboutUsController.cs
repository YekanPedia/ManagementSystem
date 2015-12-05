namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;

    public partial class AboutUsController : Controller
    {
        #region Constructure
        readonly IAboutUsService _aboutUsService;
        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }
        #endregion

        [HttpGet]
        public virtual ActionResult Update()
        {
            return View(_aboutUsService.GetAboutUsInfo());
        }

        [HttpPost]
        public virtual ActionResult Update(AboutUs model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _aboutUsService.Update(model);
            this.NotificationController().Notify(result.Message, NotificationStatus.Success);
            return View(model);
        }
    }
}
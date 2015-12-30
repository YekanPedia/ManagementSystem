namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System;
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;

    public partial class SkillsController : Controller
    {
        readonly ISkillsService _skillsService;
        public SkillsController(ISkillsService SkillsService)
        {
            _skillsService = SkillsService;
        }

        [ChildActionOnly]
        public virtual PartialViewResult GetSkillss(Guid userId)
        {
            ViewBag.UserId = userId;
            return PartialView(MVC.Skills.Views.Partial._Skills, _skillsService.GetSkillss(userId));
        }

        [HttpPost]
        public virtual JsonResult AddSkills(Skills model)
        {
            return Json(_skillsService.Add(model));
        }

        [HttpPost]
        public virtual JsonResult ChangePublicState(int skillsId)
        {
            return Json(_skillsService.ChangePublicState(skillsId));
        }

        [HttpPost]
        public virtual JsonResult Remove(int skillsId)
        {
            return Json(_skillsService.Remove(skillsId));
        }
    }
}
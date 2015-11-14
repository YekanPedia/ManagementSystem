namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using Domain.Entity;

    public partial class FeedbackController : Controller
    {
        #region Constructure
        readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        #endregion
        [HttpPost]
        public virtual JsonResult Add(Feedback model, string note)
        {
            return Json(_feedbackService.Add(model));
        }
    }
}
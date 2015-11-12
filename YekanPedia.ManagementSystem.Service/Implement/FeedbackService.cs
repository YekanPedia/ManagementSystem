namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using Interfaces;
    using Domain.Entity;
    using InfraStructure;
    using Data.Conext;
    using System.Data.Entity;
    using Properties;

    public class FeedbackService : IFeedbackService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<Feedback> _feedback;
        public FeedbackService(IUnitOfWork uow)
        {
            _uow = uow;
            _feedback = uow.Set<Feedback>();
        }
        #endregion

        public IServiceResults<Guid> Add(Feedback model)
        {
            model.SendFeedbackDate = DateTime.Now;
            model.FeedbackId = Guid.NewGuid();
            _feedback.Add(model);
            var saveResult = _uow.SaveChanges();

            return new ServiceResults<Guid>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = model.FeedbackId
            };
        }
    }
}

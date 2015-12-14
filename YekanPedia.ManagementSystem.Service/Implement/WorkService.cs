namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Context;
    using System.Data.Entity;
    using System.Linq;
    using InfraStructure;
    using Properties;

    public class WorkService : IWorkService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<Work> _work;
        public WorkService(IUnitOfWork uow)
        {
            _uow = uow;
            _work = uow.Set<Work>();
        }
        #endregion
        public IEnumerable<Work> GetWorks(Guid userId)
        {
            return _work.Where(X => X.UserId == userId).AsNoTracking().ToList();
        }

        public IServiceResults<int> Add(Work model)
        {
            _work.Add(model);
            var saveResult = _uow.SaveChanges();
            return new ServiceResults<int>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = model.WorkId
            };
        }
    }
}

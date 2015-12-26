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

        public Work Find(int workId)
        {
            return _work.Find(workId);
        }
        public IServiceResults<bool> Remove(int workId)
        {
            var work = Find(workId);
            if (work != null)
            {
                _work.Remove(work);
                var result = _uow.SaveChanges();
                return new ServiceResults<bool>
                {
                    IsSuccessfull = result.ToBool(),
                    Result = result.ToBool(),
                    Message = result.ToMessage(BusinessMessage.Error)
                };
            }
            return new ServiceResults<bool>
            {
                IsSuccessfull = false,
                Result = false,
                Message = BusinessMessage.Error
            };
        }

        public IServiceResults<bool> ChangePublicState(int workId)
        {
            var work = Find(workId);
            if (work != null)
            {
                work.IsPublic = !work.IsPublic;
                var result = _uow.SaveChanges();
                return new ServiceResults<bool>
                {
                    IsSuccessfull = result.ToBool(),
                    Result = result.ToBool(),
                    Message = result.ToMessage(BusinessMessage.Error)
                };
            }
            return new ServiceResults<bool>
            {
                IsSuccessfull = false,
                Result = false,
                Message = BusinessMessage.Error
            };
        }
    }
}

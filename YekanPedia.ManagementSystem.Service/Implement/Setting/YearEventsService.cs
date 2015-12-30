namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using Interfaces;
    using Domain.Entity;
    using InfraStructure;
    using System.Data.Entity;
    using Data.Context;
    using System.Collections.Generic;
    using System.Linq;
    using Properties;
    using InfraStructure.Date;

    public class YearEventsService : IYearEventsService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<YearEvents> _yearEvents;
        public YearEventsService(IUnitOfWork uow)
        {
            _uow = uow;
            _yearEvents = uow.Set<YearEvents>();
        }
        #endregion
        public IServiceResults<int> Add(YearEvents model)
        {
            _yearEvents.Add(model);
            var saveResult = _uow.SaveChanges();

            return new ServiceResults<int>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = model.YearEventsId
            };
        }

        public IEnumerable<YearEvents> GetYearEvents()
        {
            return _yearEvents.OrderBy(X => new { X.Month, X.Day }).AsNoTracking().ToList();
        }

        public IServiceResults<bool> Edit(YearEvents model)
        {
            _yearEvents.Attach(model);
            _uow.Entry(model).State = EntityState.Modified;
            var result = _uow.SaveChanges();
            return new ServiceResults<bool>()
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result.ToBool()
            };
        }

        public YearEvents Find(int yearEventsId)
        {
            return _yearEvents.Find(yearEventsId);
        }
        public IServiceResults<bool> Delete(int yearEventsId)
        {
            _yearEvents.Remove(Find(yearEventsId));
            var result = _uow.SaveChanges();
            return new ServiceResults<bool>
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result.ToBool()
            };
        }

        public IEnumerable<YearEvents> GetTodayEvents()
        {
            var month = PersianDateTime.Now.Month;
            var day = PersianDateTime.Now.Day;
            return _yearEvents.Where(X => X.Month == month && X.Day == day && X.IsActive).AsNoTracking().ToList();
        }
    }
}

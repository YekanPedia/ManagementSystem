namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using Interfaces;
    using Domain.Entity;
    using InfraStructure;
    using System.Data.Entity;
    using Data.Conext;
    using System.Collections.Generic;
    using System.Linq;
    using InfraStructure.Extension;
    using Properties;

    public class ClassTimeService : IClassTimeService
    {
        #region Constructure
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<ClassTime> _classTime;
        public ClassTimeService(IUnitOfWork uow)
        {
            _uow = uow;
            _classTime = uow.Set<ClassTime>();
        }
        #endregion
        public IServiceResults<int> AddClassTime(ClassTime model)
        {
            if (IsExist(model))
                return new ServiceResults<int>()
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.RecordExist,
                    Result = model.ClassTimeId
                };
            model.DayFa = model.DayEn.GetDescription();
            _classTime.Add(model);
            var saveResult = _uow.SaveChanges();
            return new ServiceResults<int>()
            {
                IsSuccessfull = saveResult != -1 ? true : false,
                Message = string.Empty,
                Result = model.ClassTimeId
            };
        }

        public IEnumerable<ClassTime> GetClassTime(Guid classId)
        {
            return _classTime.Where(X => X.ClassId == classId)
                .AsNoTracking()
                .OrderByDescending(X => X.DayEn)
                .ToList();
        }

        public bool IsExist(ClassTime model)
        {
            return _classTime.Count(X => X.DayEn == model.DayEn &&
             X.ClassId == model.ClassId &&
             X.TimeFrom == model.TimeFrom &&
             X.TimeTo == model.TimeTo) != 0 ? true : false;
        }
    }
}

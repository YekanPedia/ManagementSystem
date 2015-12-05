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
    using InfraStructure.Extension;
    using Properties;

    public class ClassTimeService : IClassTimeService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<ClassTime> _classTime;
        public ClassTimeService(IUnitOfWork uow)
        {
            _uow = uow;
            _classTime = uow.Set<ClassTime>();
        }
        #endregion
        public IServiceResults<int> AddClassTime(ClassTime model)
        {
            if (IsExist(model))
                return new ServiceResults<int>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.RecordExist,
                    Result = model.ClassTimeId
                };
            model.DayFa = model.DayEn.GetDescription();
            _classTime.Add(model);
            var result = _uow.SaveChanges();
            return new ServiceResults<int>()
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
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
             X.TimeTo == model.TimeTo) != 0;
        }

        public IServiceResults<bool> EditClassTime(ClassTime model)
        {
            _classTime.Attach(model);
            model.DayFa = model.DayEn.GetDescription();
            _uow.Entry(model).State = EntityState.Modified;
            var result = _uow.SaveChanges();
            return new ServiceResults<bool>
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result.ToBool()
            };
        }

        public ClassTime FindClassTime(int classTimeId)
        {
            return _classTime.Find(classTimeId);
        }
        public IServiceResults<bool> Delete(int classTimeId)
        {
            _classTime.Remove(_classTime.Find(classTimeId));
            var result = _uow.SaveChanges();
            return new ServiceResults<bool>
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result.ToBool()
            };
        }
    }
}

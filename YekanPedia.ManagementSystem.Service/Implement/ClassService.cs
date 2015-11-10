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
    using Properties;

    public class ClassService : IClassService
    {
        #region Constructure
         readonly IUnitOfWork _uow;
         readonly IDbSet<Class> _class;
        public ClassService(IUnitOfWork uow)
        {
            _uow = uow;
            _class = uow.Set<Class>();
        }
        #endregion
        public IServiceResults<Guid> AddClass(Class model)
        {
            model.ClassId = Guid.NewGuid();
            _class.Add(model);
            var saveResult = _uow.SaveChanges();

            return new ServiceResults<Guid>()
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = model.ClassId
            };
        }

        public IEnumerable<Class> GetClass()
        {
            return _class.Where(X => X.FinishDateMi >= DateTime.Now)
                                 .Include(X => X.ClassType)
                                 .Include(X => X.Course)
                                 .Include(X => X.User)
                                 .Include(X => X.ClassTime)
                                 .AsNoTracking()
                                 .OrderByDescending(X => X.StartDateMi)
                                 .ToList();
        }

        public IServiceResults<bool> EditClass(Class model)
        {
            _class.Attach(model);
            _uow.Entry<Class>(model).State = EntityState.Modified;
            var result = _uow.SaveChanges();
            return new ServiceResults<bool>()
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result.ToBool()
            };
        }

        public Class FindClass(Guid classId)
        {
            return _class.Find(classId);
        }

        
    }
}

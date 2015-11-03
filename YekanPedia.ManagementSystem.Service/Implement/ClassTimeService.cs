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

    public class ClassTimeService : IClassTimeService
    {
        #region Constructure
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<ClassTime> _class;
        public ClassTimeService(IUnitOfWork uow)
        {
            _uow = uow;
            _class = uow.Set<ClassTime>();
        }
        #endregion
        public IServiceResults<Guid> AddClassTime(ClassTime model)
        {
            model.ClassId = Guid.NewGuid();
            _class.Add(model);
            var saveResult = _uow.SaveChanges();

            return new ServiceResults<Guid>()
            {
                IsSuccessfull = saveResult != -1 ? true : false,
                Message = string.Empty,
                Result = model.UserId
            };
        }

        public IEnumerable<ClassTime> GetClassTime(Guid classId)
        {
            return _class.Where(X => X.FinishDateMi >= DateTime.Now)
                                 .Include(X => X.ClassType)
                                 .Include(X => X.Course)
                                 .Include(X => X.User)
                                 .AsNoTracking()
                                 .OrderByDescending(X => X.StartDateMi)
                                 .ToList();
        }
    }
}

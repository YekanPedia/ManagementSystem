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

    public class ClassService : IClassService
    {
        #region Constructure
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<Class> _class;
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
                IsSuccessfull = saveResult != -1 ? true : false,
                Message = string.Empty,
                Result = model.UserId
            };
        }

        public IEnumerable<Class> GetClass()
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

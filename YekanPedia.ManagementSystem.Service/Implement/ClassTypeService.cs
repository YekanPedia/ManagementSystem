namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using System.Linq;
    using Data.Conext;
    using System.Data.Entity;

    public class ClassTypeService : IClassTypeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<ClassType> _classType;
        public ClassTypeService(IUnitOfWork uow)
        {
            _uow = uow;
            _classType = uow.Set<ClassType>();
        }

        public IEnumerable<ClassType> GetClassType()
        {
            return _classType.Where(X => X.IsActive == true).AsNoTracking().ToList();
        }
    }
}

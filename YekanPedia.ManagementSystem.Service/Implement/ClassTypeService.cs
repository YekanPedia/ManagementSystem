namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using System.Linq;
    using Data.Context;
    using System.Data.Entity;
    using InfraStructure;
    using Properties;

    public class ClassTypeService : IClassTypeService
    {
        readonly IUnitOfWork _uow;
        readonly IDbSet<ClassType> _classType;
        public ClassTypeService(IUnitOfWork uow)
        {
            _uow = uow;
            _classType = uow.Set<ClassType>();
        }

        public IEnumerable<ClassType> GetValidClassType()
        {
            return _classType.Where(X => X.IsActive == true).AsNoTracking().ToList();
        }
        public IEnumerable<ClassType> GetAllClassType()
        {
            return _classType.AsNoTracking().ToList();
        }
        public IServiceResults<bool> ChangeClassTypeStatus(int id, bool status)
        {
            var result = FindClassType(id);
            if (result != null)
            {
                result.IsActive = status;
                var saveResult = _uow.SaveChanges();
                return new ServiceResults<bool>()
                {
                    IsSuccessfull = saveResult.ToBool(),
                    Message = saveResult.ToMessage(BusinessMessage.Error),
                    Result = saveResult.ToBool()
                };
            }
            return new ServiceResults<bool>()
            {
                IsSuccessfull = false,
                Message = BusinessMessage.RecordNotExist,
                Result = false
            };
        }
        public ClassType FindClassType(int id)
        {
            return _classType.Find(id);
        }
        public IServiceResults<int> AddClassType(string type)
        {
            _classType.Add(new ClassType()
            {
                Type = type,
                IsActive = true
            });
            var result = _uow.SaveChanges();
            return new ServiceResults<int>()
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result
            };
        }
    }
}

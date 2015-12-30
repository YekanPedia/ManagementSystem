
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

    public class IeltsMaterialService : IIeltsMaterialService
    {
        readonly IUnitOfWork _uow;
        readonly IDbSet<IeltsMaterial> _IeltsMaterial;
        public IeltsMaterialService(IUnitOfWork uow)
        {
            _uow = uow;
            _IeltsMaterial = uow.Set<IeltsMaterial>();
        }

        public IEnumerable<IeltsMaterial> UserFilesList(Guid userId)
        {
            return _IeltsMaterial.Where(X => X.UserId == userId)
                .Include(X => X.ExamType)
                .Include(X => X.Book)
                .AsNoTracking()
                .ToList();
        }

        public IServiceResults<Guid> Add(IeltsMaterial model)
        {
            _IeltsMaterial.Add(model);
            var result = _uow.SaveChanges();
            return new ServiceResults<Guid>()
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = model.IeltsMaterialId
            };
        }

        IeltsMaterial Find(Guid ieltsMaterialId)
        {
            return _IeltsMaterial.Find(ieltsMaterialId);
        }

        public IServiceResults<bool> Delete(Guid ieltsMaterialId)
        {
            var record = Find(ieltsMaterialId);
            if (record.IsComplete)
                return new ServiceResults<bool>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.NotAuthorizeForDelete,
                    Result = false
                };
            _IeltsMaterial.Remove(record);
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

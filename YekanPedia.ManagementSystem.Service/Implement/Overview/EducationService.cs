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

    public class EducationService : IEducationService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<Education> _education;
        public EducationService(IUnitOfWork uow)
        {
            _uow = uow;
            _education = uow.Set<Education>();
        }
        #endregion
        public IEnumerable<Education> GetEducations(Guid userId)
        {
            return _education.Where(X => X.UserId == userId).AsNoTracking().ToList();
        }

        public IServiceResults<int> Add(Education model)
        {
            _education.Add(model);
            var saveResult = _uow.SaveChanges();
            return new ServiceResults<int>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = model.EducationId
            };
        }

        public Education Find(int educationId)
        {
            return _education.Find(educationId);
        }

        public IServiceResults<bool> Remove(int educationId)
        {
            var education = Find(educationId);
            if (education != null)
            {
                _education.Remove(education);
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

        public IServiceResults<bool> ChangePublicState(int educationId)
        {
            var education = Find(educationId);
            if (education != null)
            {
                education.IsPublic = !education.IsPublic;
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

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
    }
}

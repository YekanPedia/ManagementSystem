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

    public class ExamTypeService : IExamTypeService
    {
        readonly IUnitOfWork _uow;
        readonly IDbSet<ExamType> _examType;
        public ExamTypeService(IUnitOfWork uow)
        {
            _uow = uow;
            _examType = uow.Set<ExamType>();
        }

        public IEnumerable<ExamType> GetValidExamType()
        {
            return _examType.Where(X => X.IsActive == true).AsNoTracking().ToList();
        }
        public IEnumerable<ExamType> GetAllExamType()
        {
            return _examType.AsNoTracking().ToList();
        }
        public IServiceResults<bool> ChangeExamTypeStatus(int id, bool status)
        {
            var result = FindExamType(id);
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
        public ExamType FindExamType(int id)
        {
            return _examType.Find(id);
        }
        public IServiceResults<int> AddExamType(string type)
        {
            _examType.Add(new ExamType()
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

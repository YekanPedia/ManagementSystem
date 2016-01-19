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

    public class SkillsService : ISkillsService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<Skills> _skills;
        public SkillsService(IUnitOfWork uow)
        {
            _uow = uow;
            _skills = uow.Set<Skills>();
        }
        #endregion
        public IEnumerable<Skills> GetSkillss(Guid userId)
        {
            return _skills.Where(X => X.UserId == userId).AsNoTracking().ToList();
        }

        public IServiceResults<int> Add(Skills model)
        {
            _skills.Add(model);
            var saveResult = _uow.SaveChanges();
            return new ServiceResults<int>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = model.SkillsId
            };
        }

        public Skills Find(int SkillsId)
        {
            return _skills.Find(SkillsId);
        }
        public IServiceResults<bool> Remove(int SkillsId)
        {
            var Skills = Find(SkillsId);
            if (Skills != null)
            {
                _skills.Remove(Skills);
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

        public IServiceResults<bool> ChangePublicState(int SkillsId)
        {
            var skills = Find(SkillsId);
            if (skills != null)
            {
                skills.IsPublic = !skills.IsPublic;
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

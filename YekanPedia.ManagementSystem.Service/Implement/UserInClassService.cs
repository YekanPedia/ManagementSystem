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

    public class UserInClassService : IUserInClassService
    {
        #region Constructur
        readonly IUnitOfWork _uow;
        readonly IDbSet<UserInClass> _userInClass;
        readonly IClassService _classService;
        public UserInClassService(IUnitOfWork uow, IClassService classService)
        {
            _uow = uow;
            _userInClass = uow.Set<UserInClass>();
            _classService = classService;
        }
        #endregion
        public IEnumerable<UserInClass> GetAllUserClass(Guid userId)
        {
            return _userInClass.Where(X => X.UserId == userId)
                .Include(X => X.Class)
                .Include(X => X.Class.ClassTime)
                .Include(X => X.Class.ClassType)
                .Include(X => X.Class.Course)
                .Include(X => X.Class.User)
                .OrderByDescending(X => X.ContributeStartDateMi)
                .AsNoTracking()
                .ToList();
        }
        public int GetUserCountInClass(Guid classId)
        {
            return _userInClass.Count(X => X.ClassId == classId);
        }
        public IServiceResults<int> Add(UserInClass model)
        {
            if (IsUniqueUserInClass((Guid)model.UserId, model.ClassId))
                return new ServiceResults<int>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.RecordExist,
                    Result = 0
                };
            model.Rebind();
            if (_classService.FindClass(model.ClassId)?.Capacity <= GetUserCountInClass(model.ClassId))
            {
                return new ServiceResults<int>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.CapacityIsFull,
                    Result = 0
                };
            }
            _userInClass.Add(model);
            var saveResult = _uow.SaveChanges();
            return new ServiceResults<int>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = model.UserInClassId
            };
        }
        public IServiceResults<bool> Edit(UserInClass model)
        {
            model.Rebind();
            _userInClass.Attach(model);
            _uow.Entry<UserInClass>(model).State = EntityState.Modified;
            var result = _uow.SaveChanges();
            return new ServiceResults<bool>()
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result.ToBool()
            };
        }
        public bool IsUniqueUserInClass(Guid userId, Guid classId)
        {
            return _userInClass.Count(X => X.UserId == userId && X.ClassId == classId) != 0;
        }
        public UserInClass Find(int userInClasssId)
        {
            return _userInClass.Find(userInClasssId);
        }
        public IServiceResults<bool> Delete(int userInClassId)
        {
            _userInClass.Remove(_userInClass.Find(userInClassId));
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

namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;
    using InfraStructure;
    using System.Linq;
    using Properties;

    public class UserService : IUserService
    {
        #region Constructur
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<User> _user;
        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
            _user = uow.Set<User>();
        }
        #endregion
        public IServiceResult<Guid> AddUser(User model)
        {
            model.UserId = Guid.NewGuid();
            model.IsActive = true;
            model.RegisterDate = DateTime.Now;
            model.LastLoginDate = DateTime.Now;
            _user.Add(model);
            _uow.SaveChanges();
            return new ServiceResult<Guid>() { IsSuccessfull = true, Message = "", Result = model.UserId };
        }

        public IServiceResult<bool> CheckEmailExist(string email)
        {
            var result = _user.Count(X => X.Email.Trim() == email);
            if (result != 0)
            {
                return new ServiceResult<bool>()
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.EmailExist,
                    Result = true
                };
            }
            return new ServiceResult<bool>()
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = false
            };
        }

        public IServiceResult<User> CheckUserExist(string email, string password)
        {
            var result = _user.FirstOrDefault(X => X.Email.Trim() == email && X.Password == password);
            if (result == null)
            {
                return new ServiceResult<User>()
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = null
                };
            }
            return new ServiceResult<User>()
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = result
            };

        }
    }
}

namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;
    using InfraStructure;

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
        public IServiceResult<int> AddUser(User model)
        {
            model.IsActive = true;
            model.RegisterDate = DateTime.Now;
            model.LastLoginDate = DateTime.Now;
            _user.Add(model);
            _uow.SaveChanges();
            return new ServiceResult<int>() { IsSuccessfull = true, Message = "", Result = model.UserId };
        }

        public void ChangeUserState(int userId, bool state = true)
        {

        }

        public IEnumerable<User> GetUserList()
        {
            throw new NotImplementedException();
        }
        public User Find(int userId) => _user.Find(userId);

    }
}

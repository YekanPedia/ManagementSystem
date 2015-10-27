namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;

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
        public void AddUser(User model)
        {
            model.IsActive = true;
            model.LastLoginDate = DateTime.Now;
            _user.Add(model);
            _uow.SaveChanges();
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

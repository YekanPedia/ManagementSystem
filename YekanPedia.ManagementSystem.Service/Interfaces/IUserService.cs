namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System.Collections.Generic;
    using Domain.Entity;

    public interface IUserService
    {
        void AddUser(User model);
        void ChangeUserState(int userId, bool state = true);
        IEnumerable<User> GetUserList();
    }
}

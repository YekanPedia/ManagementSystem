namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System.Collections.Generic;
    using Domain.Entity;
    using InfraStructure;

    public interface IUserService
    {
        IServiceResult<int> AddUser(User model);
        void ChangeUserState(int userId, bool state = true);
        IEnumerable<User> GetUserList();
    }
}

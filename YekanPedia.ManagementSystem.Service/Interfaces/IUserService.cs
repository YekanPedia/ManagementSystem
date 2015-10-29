namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System.Collections.Generic;
    using Domain.Entity;
    using InfraStructure;

    public interface IUserService
    {
        IServiceResult<int> AddUser(User model);
        IServiceResult<bool> CheckEmailExist(string email);
        IServiceResult<User> CheckUserExist(string email, string password);
    }
}

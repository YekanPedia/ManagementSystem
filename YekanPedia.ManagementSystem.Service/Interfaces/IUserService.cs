namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using InfraStructure;

    public interface IUserService
    {
        IServiceResult<Guid> AddUser(User model);
        IServiceResult<bool> CheckEmailExist(string email);
        IServiceResult<User> CheckUserExist(string email, string password);
    }
}

namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using InfraStructure;

    public interface IUserService
    {
        IServiceResults<Guid> AddUser(User model);
        IServiceResults<bool> CheckEmailExist(string email);
        IServiceResults<User> CheckUserExist(string email, string password);
        IServiceResults<bool> EditAboutMe(Guid userId, string aboutMe);
        IServiceResults<bool> EditBasicInfo(User model);
        IServiceResults<bool> EditCallInfo(User model);
        void AddLoginDate(User model);
        void AddLoginDate(Guid userId);
        IServiceResults<User> FindUser(Guid userId);
    }
}

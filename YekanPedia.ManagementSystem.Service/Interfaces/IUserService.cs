namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using InfraStructure;
    using System.Collections.Generic;

    public interface IUserService
    {
        IServiceResults<Guid> AddUser(User user, Tasks task);
        IServiceResults<bool> CheckEmailExist(string email);
        IServiceResults<User> CheckUserExist(string email, string password);
        IServiceResults<bool> EditAboutMe(Guid userId, string aboutMe);
        IServiceResults<bool> EditBasicInfo(User model);
        IServiceResults<bool> EditCallInfo(User model);
        IServiceResults<bool> ChangePicture(Guid userId, string picture);
        void AddLoginDate(User model);
        IServiceResults<User> FindUser(Guid userId);
        IServiceResults<IEnumerable<User>> GetTeachers();
    }
}

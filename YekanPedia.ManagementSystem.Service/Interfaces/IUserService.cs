namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using InfraStructure;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IUserService
    {
        IServiceResults<Guid> AddUser(User user, Tasks task);
        IServiceResults<bool> CheckEmailExist(string email);
        IServiceResults<User> CheckUserExist(string email, string password);
        IServiceResults<bool> EditAboutMe(Guid userId, string aboutMe);
        IServiceResults<bool> ChangeStatus(Guid userId, bool status);
        IServiceResults<bool> EditBasicInfo(User model);
        IServiceResults<bool> EditCallInfo(User model);
        IServiceResults<bool> ChangePicture(Guid userId, string picture);
        void AddLoginDate(User model);
        IServiceResults<User> FindUser(Guid userId);
        IServiceResults<User> FindUser(string userName);
        IServiceResults<IEnumerable<User>> GetTeachers();
        IServiceResults<IEnumerable<User>> GetUsers(User predicate, Guid? classId);
        IServiceResults<IEnumerable<User>> GetFriends(Guid userId);
        IServiceResults<bool> RecoveryPassword(string userName);
    }
}

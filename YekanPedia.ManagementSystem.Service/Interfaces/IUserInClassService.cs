namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using System.Collections.Generic;
    using InfraStructure;

    public interface IUserInClassService
    {
        IEnumerable<UserInClass> GetAllUserClass(Guid userId);
        IServiceResults<int> Add(UserInClass model);
        IServiceResults<bool> Edit(UserInClass model);
        UserInClass Find(int userInClasssId);
        IServiceResults<bool> Delete(int userInClassId);
        IEnumerable<UserInClass> GetExpiredUser();
    }
}

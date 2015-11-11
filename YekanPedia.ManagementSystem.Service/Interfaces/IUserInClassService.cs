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
    }
}

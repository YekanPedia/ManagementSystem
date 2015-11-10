namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using Domain.Entity;
    using System.Collections.Generic;

    public interface IUserInClassService
    {
        IEnumerable<UserInClass> GetAllUserClass(Guid userId);
    }
}

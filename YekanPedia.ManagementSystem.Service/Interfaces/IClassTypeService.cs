namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using Domain.Entity;
    using System.Collections.Generic;
    using InfraStructure;

    public interface IClassTypeService
    {
        IEnumerable<ClassType> GetValidClassType();
        IEnumerable<ClassType> GetAllClassType();
        IServiceResults<bool> ChangeClassTypeStatus(int id, bool status);
        ClassType FindClassType(int id);
    }
}

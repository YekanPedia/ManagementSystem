namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using Domain.Entity;
    using System.Collections.Generic;
    using InfraStructure;

    public interface IExamTypeService
    {
        IEnumerable<ExamType> GetValidExamType();
        IEnumerable<ExamType> GetAllExamType();
        IServiceResults<bool> ChangeExamTypeStatus(int id, bool status);
        ExamType FindExamType(int id);
        IServiceResults<int> AddExamType(string type);
    }
}

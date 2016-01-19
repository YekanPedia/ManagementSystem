namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain.Entity;
    using InfraStructure;

    public interface IIeltsMaterialService
    {
        IEnumerable<IeltsMaterial> UserFilesList(Guid userId);
        IEnumerable<IeltsMaterial> GetNewFiles();
        IEnumerable<IeltsMaterial> GetTodayCompleteFiles();
        IServiceResults<Guid> Complete(Guid ieltsMaterialId, float score, byte[] fileData, string extensionFile);
        IServiceResults<Guid> Add(IeltsMaterial model);
        IServiceResults<bool> Delete(Guid ieltsMaterialId);
        IeltsMaterial GetUserInfoByIeltsFile(Guid ieltsMaterialId);
        IeltsMaterial Find(Guid ieltsMaterialId);
    }
}

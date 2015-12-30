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
        IServiceResults<Guid> Add(IeltsMaterial model);
        IServiceResults<bool> Delete(Guid ieltsMaterialId);
    }
}

namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using Domain.Entity;
    using System.Collections.Generic;

    public interface IStaticFilesService
    {
        IEnumerable<StaticFiles> GetFiles(int courseId);
    }
}

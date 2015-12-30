namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Linq;
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Context;
    using System.Data.Entity;

    public class StaticFilesService : IStaticFilesService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<StaticFiles> _staticFiles;
        public StaticFilesService(IUnitOfWork uow)
        {
            _uow = uow;
            _staticFiles = uow.Set<StaticFiles>();
        }
        #endregion

        public IEnumerable<StaticFiles> GetFiles(int courseId)
        {
            return _staticFiles.Where(X => X.CourseId == courseId).AsNoTracking().ToList();
        }
    }
}

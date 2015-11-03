namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;
    using System.Linq;

    public class CourseService : ICourseService
    {
        #region Constructur
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<Course> _course;
        public CourseService(IUnitOfWork uow)
        {
            _uow = uow;
            _course = uow.Set<Course>();
        } 
        #endregion
        public IEnumerable<Course> GetCourses()
        {
            return _course.Where(X => X.IsActive).AsNoTracking().ToList();
        }
    }
}

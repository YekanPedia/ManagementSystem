namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;
    using System.Linq;
    using InfraStructure;
    using Properties;

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
        public IEnumerable<Course> GetValidCourses()
        {
            return _course.Where(X => X.IsActive).AsNoTracking().ToList();
        }
        public IEnumerable<Course> GetAllCourses()
        {
            return _course.AsNoTracking().ToList();
        }
        public IServiceResults<bool> ChangeCourseStatus(int id, bool status)
        {
            var result = FindCourse(id);
            if (result != null)
            {
                result.IsActive = status;
                var saveResult = _uow.SaveChanges();
                return new ServiceResults<bool>()
                {
                    IsSuccessfull = saveResult.ToBool(),
                    Message = saveResult.ToMessage(BusinessMessage.Error),
                    Result = saveResult.ToBool()
                };
            }
            return new ServiceResults<bool>()
            {
                IsSuccessfull = false,
                Message = BusinessMessage.RecordNotExist,
                Result = false
            };
        }
        public Course FindCourse(int id)
        {
            return _course.Find(id);
        }
    }
}

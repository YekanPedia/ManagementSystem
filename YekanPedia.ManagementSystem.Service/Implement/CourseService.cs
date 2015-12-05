namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Context;
    using System.Data.Entity;
    using System.Linq;
    using InfraStructure;
    using Properties;
    using System;

    public class CourseService : ICourseService
    {
        #region Constructur
        readonly IUnitOfWork _uow;
        readonly IDbSet<Course> _course;
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

        public IServiceResults<int> AddCourse(string type)
        {
            _course.Add(new Course()
            {
                CourseName = type,
                IsActive = true
            });
            var result = _uow.SaveChanges();
            return new ServiceResults<int>()
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result
            };
        }

        public IEnumerable<Course> GetUserCourses(Guid userId)
        {
            var result = (from course in _course
                          join cls in _uow.Set<Class>() on course.CourseId equals cls.CourseId
                          join ucls in _uow.Set<UserInClass>() on cls.ClassId equals ucls.ClassId
                          join user in _uow.Set<User>() on ucls.UserId equals user.UserId
                          where user.UserId == userId
                          select new { course, cls }).ToList();
            return result.Select(X => new Course
            {
                CourseId = X.course.CourseId,
                CourseName = X.course.CourseName,
                LogoType = X.course.LogoType,
                IsActive = !X.cls.IsFinished
            }).ToList();
        }
    }
}

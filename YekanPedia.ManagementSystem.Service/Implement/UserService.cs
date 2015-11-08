namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;
    using InfraStructure;
    using System.Linq;
    using Properties;
    using System.Linq.Expressions;

    public class UserService : IUserService
    {
        #region Constructur
        readonly IUnitOfWork _uow;
        readonly IDbSet<User> _user;
        readonly ITaskService _taskService;
        public UserService(IUnitOfWork uow, ITaskService taskService)
        {
            _uow = uow;
            _user = uow.Set<User>();
            _taskService = taskService;
        }
        #endregion
        public IServiceResults<Guid> AddUser(User user, Tasks task)
        {
            user.IsActive = true;
            user.RegisterDate = DateTime.Now;
            user.LastLoginDate = DateTime.Now;
            _user.Add(user);
            _uow.SaveChanges();
            _taskService.AddUserTask(task);
            return new ServiceResults<Guid>
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = user.UserId
            };
        }
        #region Validation check
        public IServiceResults<bool> CheckEmailExist(string email)
        {
            var result = _user.Count(X => X.Email.Trim().ToLower() == email.Trim().ToLower());
            if (result != 0)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.EmailExist,
                    Result = true
                };
            }
            return new ServiceResults<bool>
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = false
            };
        }
        public IServiceResults<User> CheckUserExist(string email, string password)
        {
            var result = _user.FirstOrDefault(X => X.Email.Trim().ToLower() == email.Trim().ToLower() && X.Password.Trim().ToLower() == password.Trim().ToLower());
            if (result == null)
            {
                return new ServiceResults<User>
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = null
                };
            }
            if (!result.IsActive)
            {
                return new ServiceResults<User>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.UserNotActive,
                    Result = null
                };
            }
            AddLoginDate(result);
            return new ServiceResults<User>
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = result
            };
        }

        #endregion
        #region ChangeLoginState
        public void AddLoginDate(User model)
        {
            model.LastLoginDate = DateTime.Now;
            _uow.SaveChanges();
        }
        #endregion
        public IServiceResults<User> FindUser(Guid userId)
        {
            var result = _user.FirstOrDefault(X => X.UserId == userId);
            if (result == null)
            {
                return new ServiceResults<User>
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = null
                };
            }
            return new ServiceResults<User>
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = result
            };
        }
        #region Edit
        public IServiceResults<bool> EditAboutMe(Guid userId, string aboutMe)
        {
            var result = _user.FirstOrDefault(X => X.UserId == userId);
            if (result == null)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = false
                };
            }
            result.AboutMe = aboutMe;
            _uow.SaveChanges();
            _taskService.EditUserTaskProgress(userId, TaskType.Profile, result.ProgressRegisterCompleted());
            return new ServiceResults<bool>
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = true
            };
        }
        public IServiceResults<bool> EditBasicInfo(User model)
        {
            var result = _user.FirstOrDefault(X => X.UserId == model.UserId);
            if (result == null)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = false
                };
            }
            result.FullName = model.FullName;
            result.Sex = model.Sex;
            result.BirthDate = model.BirthDate;
            var resultSave = _uow.SaveChanges();
            _taskService.EditUserTaskProgress(result.UserId, TaskType.Profile, result.ProgressRegisterCompleted());
            return new ServiceResults<bool>
            {
                IsSuccessfull = (resultSave.ToBool()),
                Message = string.Empty,
                Result = (resultSave.ToBool())
            };
        }
        public IServiceResults<bool> EditCallInfo(User model)
        {
            var result = _user.FirstOrDefault(X => X.UserId == model.UserId);
            if (result == null)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = false
                };
            }

            result.Facebook = model.Facebook;
            result.Twitter = model.Twitter;
            result.Mobile = model.Mobile;
            result.Email = model.Email;
            result.Latitude = model.Latitude;
            result.Longitude = model.Longitude;
            var resultSave = _uow.SaveChanges();
            _taskService.EditUserTaskProgress(result.UserId, TaskType.Profile, result.ProgressRegisterCompleted());
            return new ServiceResults<bool>
            {
                IsSuccessfull = (resultSave.ToBool()),
                Message = string.Empty,
                Result = (resultSave.ToBool())
            };
        }
        public IServiceResults<bool> ChangePicture(Guid userId, string picture)
        {
            var result = _user.FirstOrDefault(X => X.UserId == userId);
            if (result == null)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = false
                };
            }

            result.Picture = picture;
            var resultSave = _uow.SaveChanges();

            return new ServiceResults<bool>()
            {
                IsSuccessfull = (resultSave.ToBool()),
                Message = string.Empty,
                Result = (resultSave.ToBool())
            };
        }
        #endregion
        public IServiceResults<IEnumerable<User>> GetTeachers()
        {
            return new ServiceResults<IEnumerable<User>>
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = _user.Where(X => X.IsTeacher).AsNoTracking().ToList()
            };
        }
        public IServiceResults<IEnumerable<User>> GetUsers(User predicate, Guid? classId)
        {
            var model = _user.Where(X => (predicate.FullName == null || X.FullName.Contains(predicate.FullName)) &&
                 (predicate.Mobile == null || X.Mobile.Contains(predicate.Mobile)) && X.IsActive == predicate.IsActive)
                .OrderByDescending(X => X.RegisterDate).AsQueryable();

            if (classId != null)
            {
                model = (from o in model
                         join ucls in _uow.Set<UserInClass>() on o.UserId equals ucls.UserId
                         join cls in _uow.Set<Class>() on ucls.ClassId equals cls.ClassId
                         where cls.ClassId == classId
                         select o);
            }
            return new ServiceResults<IEnumerable<User>>
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = model.ToList()
            };
        }
    }
}

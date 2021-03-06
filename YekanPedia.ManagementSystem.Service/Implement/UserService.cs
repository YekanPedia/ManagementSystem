﻿namespace YekanPedia.ManagementSystem.Service.Implement
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using Domain.Entity;
    using Data.Context;
    using System.Data.Entity;
    using InfraStructure;
    using System.Linq;
    using Properties;
    using InfraStructure.Caching;
    using InfraStructure.Date;

    public class UserService : IUserService
    {
        #region Constructur
        readonly IUnitOfWork _uow;
        readonly IDbSet<User> _user;
        readonly Lazy<ITaskService> _taskService;
        readonly Lazy<INotificationService> _notificationService;
        readonly Lazy<IRoleManagementService> _roleManagementService;
        readonly Lazy<ICacheProvider> _cache;
        public UserService(IUnitOfWork uow, Lazy<ITaskService> taskService,
            Lazy<INotificationService> notificationService,
            Lazy<IRoleManagementService> roleManagementService,
             Lazy<ICacheProvider> cache)
        {
            _uow = uow;
            _user = uow.Set<User>();
            _taskService = taskService;
            _notificationService = notificationService;
            _roleManagementService = roleManagementService;
            _cache = cache;
        }
        #endregion
        public IServiceResults<Guid> AddUser(User user, Tasks task)
        {
            user.IsActive = true;
            user.RegisterDate = DateTime.Now;
            user.LastLoginDate = DateTime.Now;
            _user.Add(user);
            _uow.SaveChanges();
            #region Add Default Role
            _roleManagementService.Value.AddRole(new UserInRole { RoleId = _roleManagementService.Value.GetDefaultRole(), UserId = user.UserId });
            #endregion
            _taskService.Value.AddUserTask(task);
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
        public IServiceResults<User> FindUser(string userName)
        {
            var result = _user.FirstOrDefault(X => X.Email == userName);
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
        public IServiceResults<User> FindUser(Guid userId)
        {
            var result = _user.Find(userId);
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
            var result = FindUser(userId);
            if (result.Result == null)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = false
                };
            }
            result.Result.AboutMe = aboutMe;
            _uow.SaveChanges();
            _taskService.Value.EditUserTaskProgress(userId, TaskType.Profile, result.Result.ProgressRegisterCompleted());
            return new ServiceResults<bool>
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = true
            };
        }
        public IServiceResults<bool> EditBasicInfo(User model)
        {
            var result = FindUser(model.UserId);
            if (result.Result == null)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = false
                };
            }
            result.Result.FullName = model.FullName;
            result.Result.Sex = model.Sex;
            result.Result.BirthDate = model.BirthDate;
            result.Result.CvColor = model.CvColor;
            var resultSave = _uow.SaveChanges();
            _taskService.Value.EditUserTaskProgress(result.Result.UserId, TaskType.Profile, result.Result.ProgressRegisterCompleted());
            return new ServiceResults<bool>
            {
                IsSuccessfull = resultSave.ToBool(),
                Message = string.Empty,
                Result = resultSave.ToBool()
            };
        }
        public IServiceResults<bool> EditCallInfo(User model)
        {
            var result = FindUser(model.UserId);
            if (result.Result == null)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = false
                };
            }

            result.Result.Facebook = model.Facebook;
            result.Result.Twitter = model.Twitter;
            result.Result.Mobile = model.Mobile;
            result.Result.Email = model.Email;
            result.Result.Latitude = model.Latitude;
            result.Result.Longitude = model.Longitude;
            var resultSave = _uow.SaveChanges();
            _taskService.Value.EditUserTaskProgress(result.Result.UserId, TaskType.Profile, result.Result.ProgressRegisterCompleted());
            return new ServiceResults<bool>
            {
                IsSuccessfull = resultSave.ToBool(),
                Message = resultSave.ToMessage(BusinessMessage.Error),
                Result = resultSave.ToBool()
            };
        }
        public IServiceResults<bool> ChangePicture(Guid userId, string picture)
        {
            var result = FindUser(userId);
            if (result.Result == null)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = false
                };
            }

            result.Result.Picture = picture;
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
            var model = _user.AsQueryable();
            if (predicate != null)
            {
                model = _user.Where(X => (predicate.FullName == string.Empty || X.FullName.Contains(predicate.FullName)) &&
                              (predicate.Mobile == string.Empty || X.Mobile.Contains(predicate.Mobile)) && X.IsActive == predicate.IsActive)
                             .OrderByDescending(X => X.RegisterDate).AsQueryable();
            }
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
        public IServiceResults<bool> ChangeStatus(Guid userId, bool status)
        {
            var result = FindUser(userId);
            if (result.Result == null)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.UserNotExist,
                    Result = false
                };
            }
            result.Result.IsActive = status;
            var resultSave = _uow.SaveChanges();
            return new ServiceResults<bool>
            {
                IsSuccessfull = resultSave.ToBool(),
                Message = resultSave.ToMessage(BusinessMessage.Error),
                Result = resultSave.ToBool()
            };
        }
        public IServiceResults<bool> RecoveryPassword(string userName)
        {
            Random rnd = new Random();
            var result = FindUser(userName);
            if (result.Result == null)
            {
                return new ServiceResults<bool>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.EmailNotExist,
                    Result = false
                };
            }
            result.Result.Password = rnd.Next(100000, 999999).ToString();
            result.Result.IsResetPassword = true;
            var resultSave = _uow.SaveChanges();
            _notificationService.Value.SendNotificationToUser(result.Result.UserId, NotificationType.ResetPassword, string.Format(BusinessMessage.OTP, result.Result.Password));
            return new ServiceResults<bool>
            {
                IsSuccessfull = resultSave.ToBool(),
                Message = resultSave.ToBool() ? BusinessMessage.RecoveryPassword : BusinessMessage.Error,
                Result = resultSave.ToBool()
            };
        }

        public IEnumerable<User> GetFriends(Guid userId)
        {
            var fromCache = _cache.Value.GetItem("GetFriends");
            if (fromCache != null)
            {
                return (IEnumerable<User>)(fromCache);
            }
            var classes = (from user in _user
                           where user.UserId == userId
                           join userClass in _uow.Set<UserInClass>() on user.UserId equals userClass.UserId
                           join cls in _uow.Set<UserInClass>() on userClass.ClassId equals cls.ClassId
                           where cls.IsFinished == false
                           select cls.ClassId).ToList();
            var result = (from user in _user
                          join userClass in _uow.Set<UserInClass>() on user.UserId equals userClass.UserId
                          where classes.Contains(userClass.ClassId) && user.UserId != userId
                          select user).Distinct().ToList();
            _cache.Value.PutItem("GetFriends", result, null, DateTime.Now.AddHours(1));
            return result;
        }

        public IEnumerable<User> GetBirthDateUser()
        {
            var date = PersianDateTime.Now.ToString(PersianDateTimeFormat.Date).Substring(5, 5);
            return _user.Where(X => X.BirthDate.Substring(5, 5) == date).ToList();
        }

        public User GetUserCV(Guid userId)
        {
            return _user.Include(X => X.Education)
                .Include(X => X.Work)
                .Include(X => X.Skills)
                .Where(X => X.UserId == userId)
                .FirstOrDefault();
        }

        public IServiceResults<IEnumerable<User>> GetUsers()
        {
            return new ServiceResults<IEnumerable<User>>
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = _user.AsNoTracking().ToList()
            };
        }
    }
}

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

    public class UserService : IUserService
    {
        #region Constructur
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<User> _user;
        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
            _user = uow.Set<User>();
        }


        #endregion
        public IServiceResults<Guid> AddUser(User model)
        {
            model.UserId = Guid.NewGuid();
            model.IsActive = true;
            model.RegisterDate = DateTime.Now;
            model.LastLoginDate = DateTime.Now;
            _user.Add(model);
            _uow.SaveChanges();
            return new ServiceResults<Guid>() { IsSuccessfull = true, Message = "", Result = model.UserId };
        }

        public IServiceResults<bool> CheckEmailExist(string email)
        {
            var result = _user.Count(X => X.Email.Trim().ToLower() == email.Trim().ToLower());
            if (result != 0)
            {
                return new ServiceResults<bool>()
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.EmailExist,
                    Result = true
                };
            }
            return new ServiceResults<bool>()
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
                return new ServiceResults<User>()
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = null
                };
            }
            AddLoginDate(result);
            return new ServiceResults<User>()
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = result
            };
        }

        public void AddLoginDate(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void AddLoginDate(User model)
        {
            try
            {
                model.LastLoginDate = DateTime.Now;
                _uow.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public IServiceResults<User> FindUser(Guid userId)
        {
            var result = _user.FirstOrDefault(X => X.UserId == userId);
            if (result == null)
            {
                return new ServiceResults<User>()
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = null
                };
            }
            return new ServiceResults<User>()
            {
                IsSuccessfull = true,
                Message = string.Empty,
                Result = result
            };
        }
        public IServiceResults<bool> EditAboutMe(Guid userId, string aboutMe)
        {
            var result = _user.FirstOrDefault(X => X.UserId == userId);
            if (result == null)
            {
                return new ServiceResults<bool>()
                {
                    IsSuccessfull = true,
                    Message = BusinessMessage.UserNotExist,
                    Result = false
                };
            }
            result.AboutMe = aboutMe;
            _uow.SaveChanges();
            return new ServiceResults<bool>()
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
                return new ServiceResults<bool>()
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
            return new ServiceResults<bool>()
            {
                IsSuccessfull = (resultSave != 0 ? true : false),
                Message = string.Empty,
                Result = (resultSave != 0 ? true : false)
            };
        }
        public IServiceResults<bool> EditCallInfo(User model)
        {
            var result = _user.FirstOrDefault(X => X.UserId == model.UserId);
            if (result == null)
            {
                return new ServiceResults<bool>()
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

            return new ServiceResults<bool>()
            {
                IsSuccessfull = (resultSave != 0 ? true : false),
                Message = string.Empty,
                Result = (resultSave != 0 ? true : false)
            };
        }
    }
}

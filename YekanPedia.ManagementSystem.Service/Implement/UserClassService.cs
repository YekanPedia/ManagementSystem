namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Conext;
    using System.Data.Entity;
    using System.Linq;

    public class UserInClassService : IUserInClassService
    {
        #region Constructur
        readonly IUnitOfWork _uow;
        readonly IDbSet<UserInClass> _userInClass;
        public UserInClassService(IUnitOfWork uow)
        {
            _uow = uow;
            _userInClass = uow.Set<UserInClass>();
        }
        #endregion
        public IEnumerable<UserInClass> GetAllUserClass(Guid userId)
        {
            return _userInClass.Where(X => X.UserId == userId)
                .Include(X => X.Class)
                .OrderByDescending(X => X.ContributeStartDateMi)
                .AsNoTracking()
                .ToList();
        }
    }
}

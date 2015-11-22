namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Data.Conext;
    using System.Data.Entity;
    using Domain.Entity;
    using System.Linq;
    using InfraStructure;
    using Properties;

    public class RoleManagementService : IRoleManagementService
    {
        #region Constructure
        readonly IUnitOfWork _uow;
        readonly IDbSet<Role> _role;
        readonly IDbSet<UserInRole> _userInRole;
        readonly IDbSet<ActionRole> _actionRole;
        public RoleManagementService(IUnitOfWork uow)
        {
            _uow = uow;
            _role = uow.Set<Role>();
            _userInRole = uow.Set<UserInRole>();
            _actionRole = uow.Set<ActionRole>();
        }
        #endregion
        public IEnumerable<ActionRole> GetAvailableMenu(Guid userId)
        {
            var menu = (from role in _role
                        join userInRole in _userInRole on role.RoleId equals userInRole.RoleId
                        join actionRole in _actionRole on role.RoleId equals actionRole.RoleId
                        where userInRole.UserId == userId && actionRole.IsVisible && role.IsActive
                        orderby actionRole.Order
                        select actionRole).ToList();
            return menu;
        }
        public bool IsAuthorize(Guid userId, string controller, string action)
        {
            return true;
        }

        public IServiceResults<bool> AddRole(UserInRole model)
        {
            _userInRole.Add(model);
            var saveResult = _uow.SaveChanges();
            return new ServiceResults<bool>
            {
                IsSuccessfull = saveResult.ToBool(),
                Message = saveResult.ToMessage(BusinessMessage.Error),
                Result = saveResult.ToBool()
            };
        }
        public int GetDefaultRole()
        {
            return _role.Where(X => X.IsDefault).FirstOrDefault().RoleId;
        }
    }
}

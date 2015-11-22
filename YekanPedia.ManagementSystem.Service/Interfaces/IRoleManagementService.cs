namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System.Collections.Generic;
    using Domain.Entity;
    using System;
    using InfraStructure;

    public interface IRoleManagementService
    {
        IEnumerable<ActionRole> GetAvailableMenu(Guid userId);
        bool IsAuthorize(Guid userId, string controller, string action);
        IServiceResults<bool> AddRole(UserInRole model);
        int GetDefaultRole();
    }
}

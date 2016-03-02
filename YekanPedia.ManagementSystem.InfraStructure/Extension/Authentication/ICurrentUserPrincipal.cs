namespace YekanPedia.ManagementSystem.InfraStructure.Extension.Authentication
{
    using System;
    using System.Security.Principal;
    public interface ICurrentUserPrincipal :IPrincipal
    {
        Guid UserId { get; set; }
        string FullName { get; set; }
        string Email { get; set; }
        string Picture { get; set; }
    }
}

﻿namespace YekanPedia.ManagementSystem.InfraStructure.Extension.Authentication
{
    using System;
    using System.Security.Principal;

    public class CurrentUserPrincipal : ICurrentUserPrincipal
    {
        public IIdentity Identity { get; private set; }

        public void SetIdentity(string username)
        {
            Identity = new GenericIdentity(username);
        }
        public bool IsInRole(string role)
        {
            //return Identity != null && Identity.IsAuthenticated &&
            //!string.IsNullOrWhiteSpace(role) && Roles.IsUserInRole(Identity.Name, role);
            return false;
        }

        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Entities;
using Dependencies;
using EPAM.SocialNetwork.BLL.Interfaces;

namespace SocialNetwokPL.RoleManager
{
    public class UserRoleProvider : RoleProvider
    {
        public override void CreateRole(string roleName)
        {
            IRoleLogic roleLogic = DependencyResolver.GetInstance().RoleLogic;

            roleLogic.CreateRole(roleName);
        }  

        public override string[] GetAllRoles()
        {
            IRoleLogic roleLogic = DependencyResolver.GetInstance().RoleLogic;

            return roleLogic.GetRoles();
        }

        public override string[] GetRolesForUser(string username)
        {
            IRoleLogic roleLogic = DependencyResolver.GetInstance().RoleLogic;

            return roleLogic.GetUserRoles(username);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }



        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }        

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
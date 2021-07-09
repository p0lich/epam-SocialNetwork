using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.SocialNetwork.BLL.Interfaces;
using EPAM.SocialNetwork.DAL.Interfaces;
using Entities;

namespace SocialNetwokBLL
{
    public class RoleLogic : IRoleLogic
    {
        private IRoleDAL _roleDAL;

        public RoleLogic(IRoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }

        public bool CreateRole(string roleName)
        {
            return _roleDAL.CreateRole(new Role(roleName));
        }

        public string[] GetRoles()
        {
            return GetRolesName(_roleDAL.GetAvailableRoles());
        }

        public string[] GetUserRoles(int userId)
        {
            return GetRolesName(_roleDAL.GetUserRoles(userId));
        }

        public string[] GetUserRoles(string userLogin)
        {
            return GetRolesName(_roleDAL.GetUserRoles(userLogin));
        }

        private string[] GetRolesName(List<Role> roles)
        {
            string[] result = new string[roles.Count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = roles[i].RoleName;
            }

            return result;
        }
    }
}

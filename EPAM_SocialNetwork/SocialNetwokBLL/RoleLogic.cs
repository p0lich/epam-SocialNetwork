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

        public bool GiveRole(int userId, bool adminPermission)
        {
            try
            {
                List<Role> roles = _roleDAL.GetAvailableRoles();

                if (adminPermission)
                {
                    for (int i = 0; i < roles.Count; i++)
                    {
                        _roleDAL.GiveRole(userId, roles[i].Id);
                    }

                    return true;
                }

                _roleDAL.GiveRole(userId, roles.Where(r => r.RoleName == "user").Select(r => r.Id).First());

                return true;
            }
            catch (Exception e)
            {
                string er = e.Message;
                throw new Exception();
            }
            
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

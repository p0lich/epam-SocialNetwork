using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EPAM.SocialNetwork.DAL.Interfaces
{
    public interface IRoleDAL
    {
        bool CreateRole(Role role);

        List<Role> GetAvailableRoles();

        List<Role> GetUserRoles(int userId);

        List<Role> GetUserRoles(string userLogin);

        bool DeleteRole(int roleId);

        bool EditRole(int roleId, Role role);
    }
}

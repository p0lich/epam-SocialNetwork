using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.SocialNetwork.BLL.Interfaces
{
    public interface IRoleLogic
    {
        string[] GetRoles();

        string[] GetUserRoles(int userId);

        string[] GetUserRoles(string userLogin);

        bool CreateRole(string roleName);

        bool GiveRole(int userId, bool adminPermission);
    }
}

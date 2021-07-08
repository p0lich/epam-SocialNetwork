using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EPAM.SocialNetwork.DAL.Interfaces
{
    public interface IUserDAL
    {
        bool CreateUser(User user);

        bool RemoveUser(int userId);

        bool EditUser(int userId, User user);

        User GetUser(int userId);

        User GetUser(string userLogin);

        List<User> GetRoleUsers(int roleId);
    }
}

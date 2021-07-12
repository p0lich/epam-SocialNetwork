using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EPAM.SocialNetwork.BLL.Interfaces
{
    public interface ILogic
    {
        bool CreateUser(User user);

        bool IsLoginUnique(string login);

        User GetUser(string login);

        User GetUser(int userId);

        List<User> GetAllUsers();

        bool AddFriend(int userId, int friendId);

        List<User> GetUserFriends(int userId);

        bool RemoveFriend(int userId, int friendId);

        List<User> GetSpecificUsers(string searchWord, string gender = "empty");
    }
}

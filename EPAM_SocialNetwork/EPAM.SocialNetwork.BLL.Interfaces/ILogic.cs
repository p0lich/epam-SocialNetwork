using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;

namespace EPAM.SocialNetwork.BLL.Interfaces
{
    public interface ILogic
    {
        bool CreateUser(User user);

        bool DeleteUser(int userId);

        bool IsLoginUnique(string login);

        User GetUser(string login);

        User GetUser(int userId);

        List<User> GetAllUsers();

        bool AddFriend(int userId, int friendId);

        List<User> GetUserFriends(int userId);

        bool RemoveFriend(int userId, int friendId);

        string MoveUserImage(string userLogin, string filePath, string savePath);

        List<User> GetSpecificUsers(string searchWord, string gender = "empty");

        bool IsFriend(string currentUserLogin, string viewedUserLogin);

        bool EditUser(int userId, User user);

        bool DeleteUserImage(string filePath);
    }
}

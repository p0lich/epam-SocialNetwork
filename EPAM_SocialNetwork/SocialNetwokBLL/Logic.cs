using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entities;
using EPAM.SocialNetwork.BLL.Interfaces;
using EPAM.SocialNetwork.DAL.Interfaces;
using System.Windows.Forms;

namespace SocialNetwokBLL
{
    public class Logic : ILogic
    {
        private IUserDAL _userDAL;

        public Logic(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public bool CreateUser(User user)
        {
            return _userDAL.CreateUser(user);
        }

        public bool IsLoginUnique(string login)
        {
            User user = _userDAL.GetUser(login);
            return _userDAL.GetUser(login) == null;
        }

        public User GetUser(string login)
        {
            return _userDAL.GetUser(login);
        }

        public User GetUser(int userId)
        {
            return _userDAL.GetUser(userId);
        }

        public List<User> GetAllUsers()
        {
            return _userDAL.GetAllUsers();
        }

        public string MoveUserImage(string userLogin, string filePath, string savePath)
        {
            try
            {
                DirectoryInfo img = new DirectoryInfo(string.Format(@"{0}", filePath));

                string newFileName = userLogin + "_" + img.Name;

                string savePth = @"C:\Users\Alex\Documents\epam-SocialNetwork\EPAM_SocialNetwork\SocialNetwokPL\UsersImages\";

                File.Copy(img.FullName, $"{savePth}{newFileName}");

                return newFileName;
            }
            catch (Exception e)
            {

                throw new Exception();
            }
        }

        public List<User> GetSpecificUsers(string searchWord, string gender = "empty")
        {
            List<User> users = _userDAL.GetAllUsers();

            if (string.IsNullOrEmpty(gender) && (gender != "empty"))
            {
                return users.Where(u =>
                (u.Gender == gender) && u.Login.Contains(searchWord))
                    .OrderBy(u => u.Login).ToList();
            }

            return users.Where(u => u.Login.Contains(searchWord))
                .OrderBy(u => u.Login).ToList();
        }

        public bool AddFriend(int userId, int friendId)
        {
            return _userDAL.AddFriend(userId, friendId);
        }

        public List<User> GetUserFriends(int userId)
        {
            return _userDAL.GetUserFriends(userId);
        }

        public bool RemoveFriend(int userId, int friendId)
        {
            return _userDAL.RemoveFriend(userId, friendId);
        }

        public bool IsFriend(string currentUserLogin, string viewedUserLogin)
        {
            User currentUser = _userDAL.GetUser(currentUserLogin);
            List<User> userFriends = _userDAL.GetUserFriends(currentUser.Id);

            if (userFriends.Select(u => u.Login).Contains(viewedUserLogin))
            {
                return true;
            }

            return false;
        }

        public bool DeleteUser(int userId)
        {
            return _userDAL.RemoveUser(userId);
        }
    }
}

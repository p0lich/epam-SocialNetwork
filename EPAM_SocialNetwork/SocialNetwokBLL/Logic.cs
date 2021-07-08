using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using EPAM.SocialNetwork.BLL.Interfaces;
using EPAM.SocialNetwork.DAL.Interfaces;

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
            return _userDAL.GetUser(login).Login == login;
        }

        public User GetUser(string login)
        {
            return _userDAL.GetUser(login);
        }

        public User GetUser(int userId)
        {
            return _userDAL.GetUser(userId);
        }

        
    }
}

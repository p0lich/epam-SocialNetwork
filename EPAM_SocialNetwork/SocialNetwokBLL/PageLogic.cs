using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using EPAM.SocialNetwork.DAL.Interfaces;

namespace SocialNetwokBLL
{
    public class PageLogic
    {
        private IUserDAL _userDAL;

        public PageLogic(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        //public List<User> GetSpecificUsers(string searchWord, string gender = "empty")
        //{
        //    List<User> users = _userDAL.GetAllUsers();

        //    List<User> result = new List<User>();

        //    if (string.IsNullOrEmpty(gender) && (gender != "empty"))
        //    {
        //        return result.Where(u =>
        //        (u.Gender == gender) && u.Login.Contains(searchWord))
        //            .OrderBy(u => u.Login).ToList();
        //    }

        //    return result.Where(u => u.Login.Contains(searchWord))
        //        .OrderBy(u => u.Login).ToList();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.SocialNetwork.DAL.Interfaces;
using EPAM.SocialNetwork.BLL.Interfaces;
using SocialNetwokDAL;
using SocialNetwokBLL;

namespace Dependencies
{
    public class DependencyResolver
    {
        #region SINGLE

        private static DependencyResolver _instance;

        private DependencyResolver() { }

        public static DependencyResolver GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DependencyResolver();
            }

            return _instance;
        }

        #endregion

        public IUserDAL UserDAL => new UserDAL();
        public IRoleDAL RoleDAL => new RoleDAL();

        public ILogic UserLogic => new Logic(UserDAL);
        public IRoleLogic RoleLogic => new RoleLogic(RoleDAL);
    }
}

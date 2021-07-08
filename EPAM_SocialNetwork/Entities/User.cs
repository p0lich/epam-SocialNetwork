using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int Id { get; }

        public string Login { get; private set; }

        private string Password { get; set; }

        public List<Role> Roles { get; set; }

        // public Gender PersonGender { get; private set; }

        #region UNNECCESARY_PARAMETERS

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime? DateOfBirth { get; private set; }

        public string ImagePath { get; private set; }

        #endregion

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User(int id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}

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

        public string Gender { get; private set; }

        public List<Role> Roles { get; private set; }

        #region UNNECCESARY_PARAMETERS

        public List<Message> messages { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime? DateOfBirth { get; private set; }

        public string ImagePath { get; private set; }

        #endregion

        public User(string login, string password, string gender)
        {
            Login = login;
            Password = password;
            Gender = gender;
            messages = new List<Message>();
        }

        public User(int id, string login, string password, string gender)
        {
            Id = id;
            Login = login;
            Password = password;
            Gender = gender;
            messages = new List<Message>();
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}

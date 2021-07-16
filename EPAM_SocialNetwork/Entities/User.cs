using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        private DateTime? _dateOfBirth;

        public int Id { get; }

        public string Login { get; private set; }

        private string Password { get; set; }

        public string Gender { get; private set; }

        public List<Role> Roles { get; private set; }

        #region UNNECCESARY_PARAMETERS

        public List<Message> Messages { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime? DateOfBirth {
            get
            {
                return _dateOfBirth;
            }
            private set
            {
                if (DateTime.Now.CompareTo(value) <= 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Wrong input of birth date"));
                }

                _dateOfBirth = value;
            }
        }

        public int? Age
        {
            get
            {
                if (DateOfBirth == null)
                {
                    return null;
                }

                return DateTime.Now.Year - DateOfBirth.Value.Year;
            }
        }

        public string Image { get; private set; }

        #endregion

        public User(string login, string password, string gender)
        {
            Login = login;
            Password = password;
            Gender = gender;
            Messages = new List<Message>();
        }

        public User(int id, string login, string password, string gender)
        {
            Id = id;
            Login = login;
            Password = password;
            Gender = gender;
            Messages = new List<Message>();
        }

        public User(int id, string login)
        {
            Id = id;
            Login = login;
        }

        public User(int id, string login, string gender, string firstName, string lastName, DateTime? dateOfBirth, string imagePath)
        {
            Id = id;
            Login = login;
            Gender = gender;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Image = imagePath;
        }

        public User(int id, string login, string password, string gender, string firstName, string lastName, DateTime? dateOfBirth, string imagePath) : this(id, login, password, gender)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Image = imagePath;
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}

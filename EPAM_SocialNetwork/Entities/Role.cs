using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Role
    {
        public int Id { get; }

        public string RoleName { get; private set; }

        public Role(string role)
        {
            RoleName = role;
        }

        public Role(int id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }
    }
}

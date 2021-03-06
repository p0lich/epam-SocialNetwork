using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using EPAM.SocialNetwork.DAL.Interfaces;
using System.Data.SqlClient;

namespace SocialNetwokDAL
{
    public class RoleDAL : IRoleDAL
    {
        private const string connectionString = "Data Source=DESKTOP-83KP24G;Initial Catalog=SocialNetworkDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection _connection;

        public bool CreateRole(Role role)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.Roles_Create";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@role", role.RoleName);

                        _connection.Open();

                        command.ExecuteScalar();

                        return true;
                    }
                }
            }

            catch
            {
                throw new Exception();
            }
        }

        public bool DeleteRole(int roleId)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.Roles_Remove";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id", roleId);

                        _connection.Open();

                        command.ExecuteScalar();

                        return true;
                    }
                }
            }

            catch
            {
                throw new Exception();
            }
        }

        public bool EditRole(int roleId, Role updatedRole)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.Roles_Edit";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id", roleId);
                        command.Parameters.AddWithValue("@role", updatedRole.RoleName);

                        _connection.Open();

                        command.ExecuteScalar();

                        return true;
                    }
                }
            }

            catch
            {
                throw new Exception();
            }
        }

        public List<Role> GetAvailableRoles()
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.Roles_GetAll";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        List<Role> roles = new List<Role>();

                        while (reader.Read())
                        {
                            roles.Add(new Role(
                                id: (int)reader["Id"],
                                roleName: reader["Role"] as string
                                ));
                        }

                        return roles;
                    }
                }
            }

            catch
            {
                throw new Exception();
            }
        }

        public Role GetRole(string roleName)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.Role_GetByName";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@role", roleName);

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return new Role(
                                id: (int)reader["Id"],
                                roleName: reader["Role"] as string
                                );
                        }

                        return null;
                    }
                }
            }

            catch
            {
                throw new Exception();
            }
        }

        public List<Role> GetUserRoles(int userId)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.User_GetRoles";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id", userId);

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        List<Role> roles = new List<Role>();

                        while (reader.Read())
                        {
                            roles.Add(new Role(
                                id: (int)reader["Id"],
                                roleName: reader["Role"] as string
                                ));
                        }

                        return roles;
                    }
                }
            }

            catch
            {
                throw new Exception();
            }
        }

        public List<Role> GetUserRoles(string userLogin)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.User_GetRolesByUserLogin";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@login", userLogin);

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        List<Role> roles = new List<Role>();

                        while (reader.Read())
                        {
                            roles.Add(new Role(
                                id: (int)reader["Id"],
                                roleName: reader["Role"] as string
                                ));
                        }

                        return roles;
                    }
                }
            }

            catch
            {
                throw new Exception();
            }
        }

        public bool GiveRole(int userId, int roleId)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.Give_Role";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id_user", userId);
                        command.Parameters.AddWithValue("@id_role", roleId);

                        _connection.Open();

                        command.ExecuteScalar();

                        return true;
                    }
                }
            }

            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}

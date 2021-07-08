using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EPAM.SocialNetwork.DAL.Interfaces;


// template
/*
try
{
    using (_connection = new SqlConnection(connectionString))
    {
        string stProc = "dbo.";

        using (SqlCommand command = new SqlCommand(stProc, _connection))
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
        }
    }
}

catch
{
    throw new Exception();
}
*/


namespace SocialNetwokDAL
{
    public class UserDAL : IUserDAL
    {
        private const string connectionString = "Data Source=DESKTOP-83KP24G;Initial Catalog=SocialNetworkDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private SqlConnection _connection;

        public bool CreateUser(User user)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id_gender", -1); // temp
                        command.Parameters.AddWithValue("@login", user.Login);
                        command.Parameters.AddWithValue("@password", user.GetPassword());

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

        public bool RemoveUser(int userId)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.User_Remove";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("id", userId);

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

        public bool EditUser(int userId, User user)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.User_Edit";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // will be many parameters
                        //command.Parameters.AddWithValue("", );

                        command.Parameters.AddRange(new List<SqlParameter>() {
                            // add parameters
                            new SqlParameter("@id", user.Id)
                            
                        }.ToArray<SqlParameter>());

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

        public User GetUser(int userId)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.User_GetById";
                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id", userId);

                        var reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return new User(
                                id: (int)reader["Id"],
                                login: reader["Login"] as string,
                                password: reader["Password"] as string
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

        public User GetUser(string userLogin)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.User_GetByLogin";
                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@login", userLogin);

                        var reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return new User(
                                id: (int)reader["Id"],
                                login: reader["Login"] as string,
                                password: reader["Password"] as string
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

        public List<User> GetRoleUsers(int roleId)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.Roles_GetUsers";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        var reader = command.ExecuteReader();

                        List<User> users = new List<User>();

                        while (reader.Read())
                        {
                            // get entity of note
                        }

                        return users;
                    }
                }
            }

            catch
            {
                throw new Exception();
            }
        }
    }
}

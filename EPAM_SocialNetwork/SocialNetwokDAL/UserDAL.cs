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

            _connection.Open();
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
                    string stProc = "dbo.User_Create";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddRange(new List<SqlParameter>() {
                            // add parameters
                            new SqlParameter("@login", user.Login),
                            new SqlParameter("@password", user.GetPassword()),
                            new SqlParameter("@gender", user.Gender),
                            new SqlParameter("@firstName", user.FirstName),
                            new SqlParameter("@lastName", user.LastName),
                            new SqlParameter("@dateOfBirth", user.DateOfBirth),
                            new SqlParameter("@image", user.ImagePath)

                        }.ToArray<SqlParameter>());

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
                            new SqlParameter("@login", user.Login),
                            new SqlParameter("@password", user.GetPassword()),
                            new SqlParameter("@gender", user.Gender),
                            new SqlParameter("@firstName", user.FirstName),
                            new SqlParameter("@lastName", user.LastName),
                            new SqlParameter("@dateOfBirth", user.DateOfBirth),
                            new SqlParameter("@image", user.ImagePath)

                        }.ToArray<SqlParameter>());

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

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return new User(
                                id: (int)reader["Id"],
                                login: reader["Login"] as string,
                                password: reader["Password"] as string,
                                gender: reader["Gender"] as string
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

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return new User(
                                id: (int)reader["Id"],
                                login: reader["Login"] as string,
                                password: reader["Password"] as string,
                                gender: reader["Gender"] as string
                                );
                        }

                        return null;
                    }
                }
            }

            catch (Exception e)
            {
                string er = e.Message;
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

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        List<User> users = new List<User>();

                        while (reader.Read())
                        {
                            users.Add(new User(
                                id: (int)reader["Id"],
                                login: reader["Login"] as string,
                                password: reader["Password"] as string,
                                gender: reader["Gender"] as string
                                ));
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

        public List<User> GetUsers()
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.Users_GetAll";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        List<User> users = new List<User>();

                        while (reader.Read())
                        {
                            users.Add(new User(
                                id: (int)reader["Id"],
                                login: reader["Login"] as string,
                                password: reader["Password"] as string,
                                gender: reader["Gender"] as string
                                ));
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

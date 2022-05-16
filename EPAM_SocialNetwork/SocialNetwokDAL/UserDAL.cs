using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EPAM.SocialNetwork.DAL.Interfaces;

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

                        User a = user;

                        //command.Parameters.AddRange(new List<SqlParameter>() {
                        //    // add parameters
                        //    new SqlParameter("@login", user.Login),
                        //    new SqlParameter("@password", user.GetPassword()),
                        //    new SqlParameter("@gender", user.Gender),
                        //    new SqlParameter("@firstName", string.IsNullOrEmpty(user.FirstName) ? null : user.FirstName),
                        //    new SqlParameter("@lastName", string.IsNullOrEmpty(user.LastName)),
                        //    new SqlParameter("@dateOfBirth", string.IsNullOrEmpty(user.DateOfBirth.ToString())),
                        //    new SqlParameter("@image", string.IsNullOrEmpty(user.ImagePath))

                        //}.ToArray<SqlParameter>());

                        command.Parameters.AddWithValue("@login", user.Login);
                        command.Parameters.AddWithValue("@password", user.GetPassword());
                        command.Parameters.AddWithValue("@gender", user.Gender);

                        if (string.IsNullOrEmpty(user.FirstName))
                        {
                            command.Parameters.AddWithValue("@firstName", DBNull.Value);
                        }

                        else
                        {
                            command.Parameters.AddWithValue("@firstName", user.FirstName);
                        }

                        if (string.IsNullOrEmpty(user.LastName))
                        {
                            command.Parameters.AddWithValue("@lastName", DBNull.Value);
                        }

                        else
                        {
                            command.Parameters.AddWithValue("@lastName", user.LastName);
                        }

                        if (string.IsNullOrEmpty(user.DateOfBirth.ToString()))
                        {
                            command.Parameters.AddWithValue("@dateOfBirth", DBNull.Value);
                        }

                        else
                        {
                            command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                        }

                        if (string.IsNullOrEmpty(user.Image))
                        {
                            command.Parameters.AddWithValue("@image", DBNull.Value);
                        }

                        else
                        {
                            command.Parameters.AddWithValue("@image", user.Image);
                        }

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

                        //command.Parameters.AddRange(new List<SqlParameter>() {
                        //    // add parameters
                        //    new SqlParameter("@login", user.Login),
                        //    new SqlParameter("@password", user.GetPassword()),
                        //    new SqlParameter("@gender", user.Gender),
                        //    new SqlParameter("@firstName", user.FirstName),
                        //    new SqlParameter("@lastName", user.LastName),
                        //    new SqlParameter("@dateOfBirth", user.DateOfBirth),
                        //    new SqlParameter("@image", user.Image)
                        //}.ToArray<SqlParameter>());

                        command.Parameters.AddWithValue("@id", userId);
                        command.Parameters.AddWithValue("@login", user.Login);
                        command.Parameters.AddWithValue("@password", user.GetPassword());
                        command.Parameters.AddWithValue("@gender", user.Gender);

                        if (string.IsNullOrEmpty(user.FirstName))
                        {
                            command.Parameters.AddWithValue("@firstName", DBNull.Value);
                        }

                        else
                        {
                            command.Parameters.AddWithValue("@firstName", user.FirstName);
                        }

                        if (string.IsNullOrEmpty(user.LastName))
                        {
                            command.Parameters.AddWithValue("@lastName", DBNull.Value);
                        }

                        else
                        {
                            command.Parameters.AddWithValue("@lastName", user.LastName);
                        }

                        if (string.IsNullOrEmpty(user.DateOfBirth.ToString()))
                        {
                            command.Parameters.AddWithValue("@dateOfBirth", DBNull.Value);
                        }

                        else
                        {
                            command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                        }

                        if (string.IsNullOrEmpty(user.Image))
                        {
                            command.Parameters.AddWithValue("@image", DBNull.Value);
                        }

                        else
                        {
                            command.Parameters.AddWithValue("@image", user.Image);
                        }

                        _connection.Open();

                        command.ExecuteScalar();

                        return true;
                    }           
                }
            }

            catch (Exception e)
            {
                string er = e.Message;
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
                                gender: reader["Gender"] as string,
                                firstName: reader["FirstName"] as string,
                                lastName: reader["LastName"] as string,
                                dateOfBirth: reader["DateOfBirth"] as DateTime?,
                                imagePath: reader["Image"] as string
                                );
                        }

                        return null;
                    }
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
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

                        if (reader.Read() && reader.HasRows)
                        {
                            return new User(
                                id: (int)reader["Id"],
                                login: reader["Login"] as string,
                                password: reader["Password"] as string,
                                gender: reader["Gender"] as string,
                                firstName: reader["FirstName"] as string,
                                lastName: reader["LastName"] as string,
                                dateOfBirth: reader["DateOfBirth"] as DateTime?,
                                imagePath: reader["Image"] as string
                                );
                        }

                        return null;
                    }
                }
            }

            catch (Exception e)
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

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        List<User> users = new List<User>();

                        while (reader.Read())
                        {
                            users.Add(new User(
                                id: (int)reader["Id"],
                                login: reader["Login"] as string,
                                gender: reader["Gender"] as string,
                                firstName: reader["FirstName"] as string,
                                lastName: reader["LastName"] as string,
                                dateOfBirth: reader["DateOfBirth"] as DateTime?,
                                imagePath: reader["Image"] as string
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

        public List<User> GetAllUsers()
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.User_GetAll";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        List<User> result = new List<User>();

                        while (reader.Read())
                        {
                            result.Add(new User(
                                id: (int)reader["Id"],
                                login: reader["Login"] as string,
                                gender: reader["Gender"] as string,
                                firstName: reader["FirstName"] as string,
                                lastName: reader["LastName"] as string,
                                dateOfBirth: reader["DateOfBirth"] as DateTime?,
                                imagePath: reader["Image"] as string
                                ));
                        }

                        return result;
                    }
                }
            }

            catch
            {
                throw new Exception();
            }
        }

        public bool AddFriend(int userId, int friendId)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.User_AddFriend";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id_user", userId);
                        command.Parameters.AddWithValue("@id_friend", friendId);

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

        public List<User> GetUserFriends(int userId)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.User_GetFriends";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id", userId);

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        List<User> result = new List<User>();

                        while (reader.Read())
                        {
                            result.Add(new User(
                                id: (int)reader["Id"],
                                login: reader["Login"] as string,
                                gender: reader["Gender"] as string,
                                firstName: reader["FirstName"] as string,
                                lastName: reader["LastName"] as string,
                                dateOfBirth: reader["DateOfBirth"] as DateTime?,
                                imagePath: reader["Image"] as string
                                ));
                        }

                        return result;
                    }
                }
            }

            catch
            {
                throw new Exception();
            }
        }

        public bool RemoveFriend(int userId, int friendId)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.User_RemoveFriend";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id_user", userId);
                        command.Parameters.AddWithValue("@id_friend", friendId);

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
    }
}

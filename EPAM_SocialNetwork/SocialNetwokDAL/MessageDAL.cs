using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;
using EPAM.SocialNetwork.DAL.Interfaces;

namespace SocialNetwokDAL
{
    public class MessageDAL : IMessageDAL
    {
        private const string connectionString = "Data Source=DESKTOP-83KP24G;Initial Catalog=SocialNetworkDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private SqlConnection _connection;

        public bool CreateMessage(Message message)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.Message_Create";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id_sender", message.Sender.Id);
                        command.Parameters.AddWithValue("@id_addresse", message.Addresse.Id);
                        command.Parameters.AddWithValue("@messageText", message.MessageText);
                        command.Parameters.AddWithValue("@creationDate", message.CreationDate);

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

        public bool EditMessage(int messageId, string newMessageText, DateTime editDate)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.Message_Edit";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id", messageId);
                        command.Parameters.AddWithValue("@messageText", newMessageText);
                        command.Parameters.AddWithValue("@editDate", editDate);

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

        public List<Message> GetAllUserMessages(int userId)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.User_GetAllMessages_WithProperties";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id", userId);

                        _connection.Open();

                        var reader = command.ExecuteReader();

                        List<Message> result = new List<Message>();

                        while (reader.Read())
                        {
                            User sender = new User(
                                id: (int)reader["Id_Sender"],
                                login: reader["SenderLogin"] as string
                                );

                            User addresse = new User(
                                id: (int)reader["Id_Addresse"],
                                login: reader["AddresseLogin"] as string
                                );

                            result.Add(new Message(
                                id: (int)reader["Id"],
                                sender: sender,
                                addresse: addresse,
                                messageText: reader["MessageText"] as string,
                                creationDate: (DateTime)reader["CreationDate"],
                                editDate: reader["EditDate"] as DateTime?
                                ));
                        }

                        return result;
                    }
                }
            }

            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public bool RemoveMessage(int messageId)
        {
            try
            {
                using (_connection = new SqlConnection(connectionString))
                {
                    string stProc = "dbo.Message_Remove";

                    using (SqlCommand command = new SqlCommand(stProc, _connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id", messageId);

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

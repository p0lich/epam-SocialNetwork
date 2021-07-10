using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using EPAM.SocialNetwork.BLL.Interfaces;
using EPAM.SocialNetwork.DAL.Interfaces;

namespace SocialNetwokBLL
{
    public class MessageLogic : IMessageLogic
    {
        private IMessageDAL _messageDAL;

        public MessageLogic(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public bool DeleteMessage(int messageId)
        {
            return _messageDAL.RemoveMessage(messageId);
        }

        public bool EditMessage(int messageId, string newMessageText, DateTime editDate)
        {
            return _messageDAL.EditMessage(messageId, newMessageText, editDate);
        }

        public List<Message> GetMessageHistory(int userId)
        {
            return _messageDAL.GetAllUserMessages(userId);
        }

        public bool SendMessage(User sender, User addresse, string messageText, DateTime creationDate)
        {
            return _messageDAL.CreateMessage(new Message(sender, addresse, messageText, creationDate, null));
        }
    }
}

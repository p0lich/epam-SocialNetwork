using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EPAM.SocialNetwork.DAL.Interfaces
{
    public interface IMessageDAL
    {
        bool CreateMessage(Message message);

        bool RemoveMessage(int messageId);

        bool EditMessage(int messageId, string newMessageText, DateTime editDate);

        List<Message> GetAllUserMessages(int userId);
    }
}

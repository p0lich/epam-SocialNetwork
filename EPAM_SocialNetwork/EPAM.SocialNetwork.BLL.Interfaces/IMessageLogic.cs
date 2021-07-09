using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EPAM.SocialNetwork.BLL.Interfaces
{
    public interface IMessageLogic
    {
        bool SendMessage(User sender, User addresse, string messageText, DateTime creationDate);

        bool EditMessage(int messageId, string newMessageText, DateTime editDate);

        bool DeleteMessage(int messageId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Message
    {
        public int Id { get; }

        public User Sender { get; private set; }

        public User Addresse { get; private set; }

        public string MessageText { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime? EditDate { get; private set; }

        public Message(User sender, User addresse, string messageText, DateTime creationDate, DateTime? editDate)
        {
            Sender = sender;
            Addresse = addresse;
            MessageText = messageText;
            CreationDate = creationDate;
            EditDate = editDate;
        }

        public Message(int id, User sender, User addresse, string messageText, DateTime creationDate, DateTime? editDate)
        {
            Id = id;
            Sender = sender;
            Addresse = addresse;
            MessageText = messageText;
            CreationDate = creationDate;
            EditDate = editDate;
        }
    }
}

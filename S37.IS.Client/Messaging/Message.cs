using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client.Messaging
{
    public class Message
    {
        public Guid MessageId { get; private set; }

        public object Body { get; set; }

        public Message() { MessageId = Guid.NewGuid(); }
    }
}

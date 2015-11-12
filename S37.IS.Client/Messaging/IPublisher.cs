using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client.Messaging
{
    public class Result
    {

    }

    public interface IPublisher
    {
        Task PublishAsync(Message message);
    }
}

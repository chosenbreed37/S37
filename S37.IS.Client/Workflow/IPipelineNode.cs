using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client.Messaging
{
    public interface IPipelineNode
    {
        IDisposable LinkTo(IPipelineNode node);

        Task<bool> SendAsync(Message message);
    }
}

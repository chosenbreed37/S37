using S37.IS.Client.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client.Messaging
{
    public class Publisher : IPublisher
    {
        private IPipeline corePipeline;

        public Publisher(IPipeline pipeline)
        {
            corePipeline = pipeline;
        }

        public Task PublishAsync(Message message)
        {
            corePipeline.Push(message);
            return Task.FromResult(true);
        }
    }
}

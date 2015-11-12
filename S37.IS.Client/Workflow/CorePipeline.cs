using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S37.IS.Client.Messaging;
using System.Threading.Tasks.Dataflow;

namespace S37.IS.Client.Workflow
{
    public class CorePipeline : IPipeline
    {
        private ActionBlock<Message> queueWriter;
        private TransformBlock<Message, Message> logger;

        public CorePipeline()
        {
            logger.LinkTo(queueWriter);
        }

        public Task<bool> Push(Message message)
        {
            return queueWriter.SendAsync(message);
        }
    }
}

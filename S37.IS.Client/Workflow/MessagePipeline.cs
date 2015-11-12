using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace S37.IS.Client.Workflow
{
    public class MessagePipeline
    {
        private DataflowLinkOptions linkOptions;

        private TransformBlock<object, Messaging.Message> buildMessage;

        private TransformBlock<Messaging.Message, Messaging.Message> logMessage;

        private TransformBlock<Messaging.Message, Messaging.Message> sendMessage;

        public MessagePipeline()
        {
            linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            buildMessage = new TransformBlock<object, Messaging.Message>(
                x => {
                    Console.WriteLine("buildMessage| message: {0}", x);
                    return new Messaging.Message { Body = x };
                });

            logMessage = new TransformBlock<Messaging.Message, Messaging.Message>
                (x => {
                    Console.WriteLine("logMessage| MessageId: {0}. Body: {1}.", x.MessageId, x.Body);
                    return x;
                });

            sendMessage = new TransformBlock<Messaging.Message, Messaging.Message>(
                x => {
                    Console.WriteLine("sendMessage| MessageId: {0}. Body: {1}.", x.MessageId, x.Body);
                    return x;
                });

            buildMessage.LinkTo(logMessage, linkOptions);
            logMessage.LinkTo(sendMessage, linkOptions);
        }

        public Task Push(object message)
        {
            buildMessage.SendAsync(message);
            buildMessage.Complete();
            return sendMessage.ReceiveAsync();
        }        
    }
}

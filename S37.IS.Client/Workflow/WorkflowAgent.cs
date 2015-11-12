using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client.Workflow
{
    public class WorkflowAgent : IWorkflowAgent
    {
        public IObservable<string> GetMessageStream()
        {
            return Observable.Empty<string>();
        }

        public void SubscribeTo(IWorkflowAgent target)
        {
            var subscription = target.GetMessageStream().Subscribe(Console.WriteLine);
        }
    }
}

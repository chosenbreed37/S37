using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client.Workflow
{
    public interface IWorkflowAgent
    {
        IObservable<string> GetMessageStream();

        void SubscribeTo(IWorkflowAgent target);
    }
}

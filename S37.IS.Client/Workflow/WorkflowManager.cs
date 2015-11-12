using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client.Workflow
{
    public class WorkflowManager
    {
        private IWorkflowAgent _publisher;
        private IWorkflowAgent _amqpWriter;
        private IWorkflowAgent _hospital;
        private IWorkflowAgent _fileReader;
        private IWorkflowAgent _databaseReader;
        private IWorkflowAgent _customProcessing;
        private IWorkflowAgent _auditor;
        private IWorkflowAgent _api;

        public WorkflowManager()
        {
            _customProcessing.SubscribeTo(_publisher);
            _amqpWriter.SubscribeTo(_customProcessing);
            _hospital.SubscribeTo(_customProcessing);
        }

        public void WithApi()
        {
            _publisher.SubscribeTo(_api);
        }

        public void WithFileReader()
        {
            _publisher.SubscribeTo(_fileReader);
            _fileReader.SubscribeTo(_amqpWriter);
            _fileReader.SubscribeTo(_hospital);
        }

        public void WithDatabaseReader()
        {
            _publisher.SubscribeTo(_databaseReader);
            _databaseReader.SubscribeTo(_amqpWriter);
            _databaseReader.SubscribeTo(_hospital);
        }
    }
}

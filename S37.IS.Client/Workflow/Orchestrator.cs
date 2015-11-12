using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace S37.IS.Client.Workflow
{
    public class Orchestrator
    {
        private BufferBlock<string> _publisher = new BufferBlock<string>();

        private BufferBlock<string> _filerReader = new BufferBlock<string>();

        private BufferBlock<string> _databaseReader = new BufferBlock<string>();

        private BufferBlock<string> _hospital = new BufferBlock<string>();

        private BufferBlock<string> _auditor = new BufferBlock<string>();

        private BufferBlock<string> _amqpWriter = new BufferBlock<string>();

        private TransformBlock<string, string> _customProcessor = new TransformBlock<string, string>(x => x);

        public Orchestrator()
        {
            _publisher.LinkTo(_customProcessor);
            _customProcessor.LinkTo(_amqpWriter);
            _customProcessor.LinkTo(_hospital);
        }

        public Orchestrator WithFileReader()
        {
            _filerReader.LinkTo(_publisher);
            _hospital.LinkTo(_filerReader);
            _amqpWriter.LinkTo(_filerReader);
            return this;
        }

        public Orchestrator WithDatabaseReader()
        {
            _databaseReader.LinkTo(_publisher);
            _hospital.LinkTo(_databaseReader);
            _amqpWriter.LinkTo(_databaseReader);
            return this;
        }
    }
}

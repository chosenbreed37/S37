using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client.Host
{
    public class IntegrationService
    {
        private FileListener _reader;

        public IntegrationService()
        {
            _reader = new FileListener(@"d:\temp\s37");
        }

        public void Start()
        {
            _reader.GetFilesAsObservable()
                .Subscribe(x => Task.Run(() => Console.WriteLine("Received: {0}", x)));
        }

        public void Stop() { _reader.Dispose(); }
    }
}

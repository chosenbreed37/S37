using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client
{
    public class FileReaderResult
    {
        public object Header { get; private set; }
        public object Data { get; private set; }
    }

    public class FileReader
    {
        public FileReaderResult ReadAsync(string filenameWithoutExtension)
        {
            return null;
        }
    }
}

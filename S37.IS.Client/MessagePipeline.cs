using S37.IS.Client.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client
{
    public class MessagePipeline
    {
        public IConfigurationSettingsProvider ConfigurationSettingsProvider { get; set; }

        public IMessageContextProvider MessageContextProvider { get; set; }
    }
}

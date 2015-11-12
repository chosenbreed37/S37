using S37.IS.Client.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client.Workflow
{
    public interface IPipelineContext
    {
        ConfigurationSettings Configuration { get; set; }
    }
}

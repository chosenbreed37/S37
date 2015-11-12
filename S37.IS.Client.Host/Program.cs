using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using System.Reactive.Linq;

namespace S37.IS.Client.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<IntegrationService>(s => 
                {
                    s.ConstructUsing(name => new IntegrationService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("S37 Integration Service Client Host");
                x.SetDisplayName("S37 Integration Service");
                x.SetServiceName("S37.IS.CLIENT.HOST");
            });
        }
    }
}

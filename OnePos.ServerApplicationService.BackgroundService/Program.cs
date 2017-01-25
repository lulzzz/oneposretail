using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;


namespace OnePos.ServerApplicationService.BackgroundService
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new StoreSetupService();

            if (bool.Parse(ConfigurationManager.AppSettings["RunAsConsole"]))
            {
                service.Start();
                Console.ReadLine();
                service.Stop();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    service
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}

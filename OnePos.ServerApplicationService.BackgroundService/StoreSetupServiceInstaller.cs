using System.ComponentModel;
using System.ServiceProcess;

namespace OnePos.ServerApplicationService.BackgroundService
{
    [RunInstaller(true)]
    partial class StoreSetupServiceInstaller : System.Configuration.Install.Installer
    {
        public StoreSetupServiceInstaller()
        {
            InitializeComponent();

            var serviceProcessInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();

            //# Service Account Information

            serviceProcessInstaller.Account = ServiceAccount.NetworkService;

            //# Service Information

            serviceInstaller.DisplayName = "OnePOS Store Setup Service";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            //# This must be identical to the WindowsService.ServiceBase name

            //# set in the constructor of WindowsService.cs

            serviceInstaller.ServiceName = "OnePOS Store Setup Service";

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
        }
 
    }
}

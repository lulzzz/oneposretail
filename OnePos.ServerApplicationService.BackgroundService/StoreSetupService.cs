using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using OnePos.Domain;
using OnePos.Framework;
using OnePos.Persistance;
using log4net;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
//using System.Data.OracleClient; 
using OnePos.DataCollector;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text;
using OnePos.Domain.Encryption;
using OnePos.MessageService;

namespace OnePos.ServerApplicationService.BackgroundService
{
    partial class StoreSetupService : ServiceBase
    {
        private readonly static ILog _log = LogManager.GetLogger(typeof(StoreSetupService));

        private static bool _interuptThread;
        private static readonly IDependencyContainer _container = DependencyContainer.Default;
        private static IOnePosEntitiesFactory _contextFactory;
        private Thread _mainThreadLoop;

        //private Thread _downloadSubmissionResultExportThreadLoop; 
        //private Thread _profilingdataLoop;

        public StoreSetupService()
        {
            InitializeComponent();

            var bootstrap = new Bootstrap(_container);
            bootstrap.Initilise();

            _contextFactory = _container.Resolve<IOnePosEntitiesFactory>();
        }

        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.

            _interuptThread = false;

            _mainThreadLoop = new Thread(ExecuteStoreSetupLoop);
            _mainThreadLoop.Start();

            //_downloadSubmissionResultExportThreadLoop = new Thread(DownloadSubmissionResultExportThreadLoop);
            //_downloadSubmissionResultExportThreadLoop.Start();

            //_profilingdataLoop = new Thread(ProfilingDataLoop);
            //_profilingdataLoop.Start();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.

            _interuptThread = true;

            if (!_mainThreadLoop.Join(new TimeSpan(0, 1, 0)))
                _mainThreadLoop.Interrupt();

            //if (!_downloadSubmissionResultExportThreadLoop.Join(new TimeSpan(0, 1, 0)))
            //    _downloadSubmissionResultExportThreadLoop.Interrupt(); 

            //if (!_profilingdataLoop.Join(new TimeSpan(0, 1, 0)))
            //    _profilingdataLoop.Interrupt();

            _container.Release(_contextFactory);

        }



        private static void ExecuteStoreSetupLoop()
        {

            while (!_interuptThread)
            {
                try
                {
                    using (var context = _contextFactory.Create())
                    {
                        var dataSourceName = "himasankar-pc"; 
                        var dbUserName = "sa";
                        var dbPassword = "12345";                       

                        TwoWayEncryptionDecryption Encrypt = new TwoWayEncryptionDecryption();
                        var objectContext = ((IObjectContextAdapter)context).ObjectContext;
                        objectContext.CommandTimeout = 0;

                        var processingStatuses = new List<OnePosStoreStatusEnum>
                                {
                                    OnePosStoreStatusEnum.Queued,
                                    //OnePosStoreStatusEnum.DataCopying,
                                    //OnePosStoreStatusEnum.DatabaseCreating
                                }.Select(x => (int)x).ToArray();

                        var storeInfo = context.GetOnePosStores().AsEnumerable().OrderBy(x => (long)x["ID"])
                            .FirstOrDefault(x => processingStatuses.Any(y => y == (int)x["StoreStatus"])); 

                        if (storeInfo == null)
                        {
                            Thread.Sleep(new TimeSpan(0, 0, 10));
                            continue;
                        } 

                        if ((int)storeInfo["StoreStatus"] == (int)OnePosStoreStatusEnum.Queued)
                        {
                          
                            context.UpdateOnePosStoreStatus((long)storeInfo["ID"], (int)OnePosStoreStatusEnum.DatabaseCreating);

                            var storetypeExistingDBInfo = context.GetOnePosStoreDatabases().AsEnumerable().Where(x => (int)x["StoreTypeId"] == (int)storeInfo["StoreTypeId"]).ToList();


                            if (storetypeExistingDBInfo.Count <= 0)
                            {
                                var DBName = context.GetOnePosStoreTypes().AsEnumerable().Where(x => (int)x["StoreTypeId"] == (int)storeInfo["StoreTypeId"]).FirstOrDefault().Field<string>("VerticalDatabaseName");
                                var newMainDBName = DBName + "_MainDB";
                                var newBackupDBName = DBName + "_BackupDB";

                                var tpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).Replace(@"\bin\Debug", string.Empty); ;

                                FileInfo file = new FileInfo(tpath + "\\DBScript\\oneposSchema.sql");
                                string script = file.OpenText().ReadToEnd();
                                var newMainDBscript = "use [" + newMainDBName + "]" + script;
                                var newBackupDBscript = "use [" + newBackupDBName + "]" + script;

                                SqlConnectionStringBuilder connectionstring = new SqlConnectionStringBuilder();
                                connectionstring.InitialCatalog = "master";
                                connectionstring.DataSource = dataSourceName;
                                connectionstring.UserID = dbUserName;
                                connectionstring.Password = dbPassword;
                                string connectionString = connectionstring.ConnectionString;// ConfigurationManager.ConnectionStrings["MasterDBConnectionString"].ToString();
                                GetDatabaseInfo info = new GetDatabaseInfo();
                                IDatabase db = info.GetDatabase("SqlServer", connectionString);

                                var IsExecuted = db.ExecuteSQLQuery("CREATE DATABASE " + newMainDBName);
                                if (IsExecuted == true)
                                    _log.Info(String.Format("Main database {0} has been created", newMainDBName));
                                else
                                    _log.Error(String.Format("Main database {0} creation failed", newMainDBName));

                                IsExecuted = db.ExecuteSQLQuery("CREATE DATABASE " + newBackupDBName);

                                if (IsExecuted == true)
                                    _log.Info(String.Format("Backup database {0} has been created", newBackupDBName));
                                else
                                    _log.Error(String.Format("Backup database {0} creation failed", newBackupDBName));


                                _log.Info(String.Format("Creating schema for {0}", newMainDBName));
                                IsExecuted = db.ExecuteSQLQuery(newMainDBscript);

                                if (IsExecuted == true)
                                {
                                    _log.Info(String.Format("Database schema has been created successfully for {0}.", newMainDBName));
                                    context.CreateVerticalDatabaseConnections(dataSourceName, newMainDBName, dbUserName, Encrypt.Encrypt(dbUserName), (int)storeInfo["StoreTypeId"], 1);
                                }
                                else
                                    _log.Error(String.Format("Database schema creation failed for {0}.", newMainDBName));


                                _log.Info(String.Format("Creating schema for {0}", newBackupDBName));
                                IsExecuted = db.ExecuteSQLQuery(newBackupDBscript);

                                if (IsExecuted == true) {
                                    _log.Info(String.Format("Database schema has been created successfully for {0}.", newBackupDBName));
                                    context.CreateVerticalDatabaseConnections(dataSourceName, newBackupDBName, dbUserName, Encrypt.Encrypt(dbUserName), (int)storeInfo["StoreTypeId"], 0);
                                }  
                                else
                                    _log.Error(String.Format("Database schema creation failed for {0}.", newBackupDBName));

                                if (IsExecuted == true)
                                {
                                    var storetypeExistingDBInfoNew = context.GetOnePosStoreDatabases().AsEnumerable().Where(x => (int)x["StoreTypeId"] == (int)storeInfo["StoreTypeId"]).ToList();

                                    var MainDBConnectionID = storetypeExistingDBInfoNew.Where(x => (bool)x["IsMainDB"] == true).FirstOrDefault().Field<int>("ConnectionId");
                                    var BackupDBConnectionID = storetypeExistingDBInfoNew.Where(x => (bool)x["IsMainDB"] == false).FirstOrDefault().Field<int>("ConnectionId");
                                    context.UpdateOnePosStoreDatabaseConnections((long)storeInfo["ID"], MainDBConnectionID, BackupDBConnectionID); 

                                    context.UpdateOnePosStoreStatus((long)storeInfo["ID"], (int)OnePosStoreStatusEnum.SetupCompleted);

                                    //SEND EMAIL TO STORE OWNER WITH LOGIN CREADENTIALS FOR ADMIN PANEL.////////

                                    GetMessageServiceInfo getmessageserviceinfo = new GetMessageServiceInfo();
                                    IMessageServices imessageservices = getmessageserviceinfo.GetMessageService("Email");
                                    var isMessageSent = imessageservices.SendMessage("OnePos retail login details.", string.Format("Hi {0}, \n\n\tOnePOS retail account has been created successfully. Please use the following creadentials to access admin panel.\n\n Admin panel url : www.oneposretail.com \n UserName : {1} \n Password : {2}", storeInfo["StoreOwnerName"].ToString(), storeInfo["AdminUsername"].ToString(), Encrypt.Decrypt(storeInfo["AdminPassword"].ToString())), storeInfo["EmailId"].ToString());
                                    _log.Info(String.Format("Database setup has been completed for {0}", storeInfo["StoreName"]));
                                }
                                else
                                {
                                    context.UpdateOnePosStoreStatus((long)storeInfo["ID"], (int)OnePosStoreStatusEnum.Failed);
                                    _log.Error(String.Format("Database setup failed for {0}.", storeInfo["StoreName"]));
                                }
                              
                            }
                            else
                            {
                                var MainDBConnectionID = storetypeExistingDBInfo.Where(x => (bool)x["IsMainDB"] == true).FirstOrDefault().Field<int>("ConnectionId");
                                var BackupDBConnectionID = storetypeExistingDBInfo.Where(x => (bool)x["IsMainDB"] == false).FirstOrDefault().Field<int>("ConnectionId");
                                context.UpdateOnePosStoreDatabaseConnections((long)storeInfo["ID"], MainDBConnectionID, BackupDBConnectionID);

                                context.UpdateOnePosStoreStatus((long)storeInfo["ID"], (int)OnePosStoreStatusEnum.SetupCompleted);

                                //SEND EMAIL TO STORE OWNER WITH LOGIN CREADENTIALS FOR ADMIN PANEL.////////

                                GetMessageServiceInfo getmessageserviceinfo = new GetMessageServiceInfo();
                                IMessageServices imessageservices = getmessageserviceinfo.GetMessageService("Email");
                                var isMessageSent = imessageservices.SendMessage("OnePos retail login details.", string.Format("Hi {0}, \n\n\tOnePOS retail account has been created successfully. Please use the following creadentials to access admin panel.\n\n Admin panel url : www.oneposretail.com \n UserName : {1} \n Password : {2}", storeInfo["StoreOwnerName"].ToString(), storeInfo["AdminUsername"].ToString(), Encrypt.Decrypt(storeInfo["AdminPassword"].ToString())), storeInfo["EmailId"].ToString());
                                 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message, ex);
                }

                Thread.Sleep(new TimeSpan(0, 0, 10));
            }
        }




    }
}

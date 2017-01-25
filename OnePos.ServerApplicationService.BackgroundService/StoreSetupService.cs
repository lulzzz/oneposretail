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
                        var objectContext = ((IObjectContextAdapter)context).ObjectContext;
                        objectContext.CommandTimeout = 0;

                        var processingStatuses = new List<OnePosStoreStatusEnum>
                                {
                                    OnePosStoreStatusEnum.Queued,
                                    OnePosStoreStatusEnum.DataCopying,
                                    OnePosStoreStatusEnum.DatabaseCreating
                                }.Select(x => (int)x).ToArray();

                        var storeInfo = context.OnePosStores.OrderBy(x => x.ID)
                            .FirstOrDefault(x => processingStatuses.Any(y => y == x.StoreStatus));

                        if (storeInfo == null)
                        {
                            Thread.Sleep(new TimeSpan(0, 0, 10));
                            continue;
                        } 

                        if (storeInfo.StoreStatus == (int)OnePosStoreStatusEnum.Queued)
                        {

                            //if (!RunImport(context, submission))
                            //{
                            //    Thread.Sleep(new TimeSpan(0, 0, 10));
                            //    continue;
                            //}

                            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                            GetDatabaseInfo info = new GetDatabaseInfo();
                            IDatabase db = info.GetDatabase("SqlServer", connectionString);
                            DateTime expiryDate = db.GetExpiryDate(connectionString);
                            DateTime currentDate = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day);
                            //if (currentDate <= expiryDate)
                            //{

                            //    var recordDuration = Stopwatch.StartNew();
                            //    var submissionData = submission.SubmissionDatas
                            //                            .First(x => x.Id == submission.CurrentSubmissionDataId);

                            //    _log.Info(String.Format("Get current submission duration: {0} seconds", recordDuration.Elapsed.Seconds));
                            //    recordDuration.Restart();


                            //    var submissionDataSetId = submission.DataSetId;
                            //    var submissionId = submission.Id;
                            //    var totalColumns = context.DataSetColumns
                            //                        .Where(x => x.DataSetId == submissionDataSetId)
                            //                        .Select(c => c.ColumnTypeId).Distinct().Count();
                            //    var totalGroups = context.BusinessRules
                            //                        .Where(x => x.BusinessRuleGroup.DataSetId == submissionDataSetId)
                            //                        .Count(x => x.IsEnabled);
                            //    var totalBusinessRules = totalColumns + totalGroups;

                            //    _log.Info(String.Format("Get total validation rules duration: {0} seconds", recordDuration.Elapsed.Seconds));
                            //    recordDuration.Restart();

                            //    var totalDataRows = context.SubmissionDataRows.Count(x => x.SubmissionDataId == submissionId);

                            //    _log.Info(String.Format("Get total submission data rows duration: {0} seconds", recordDuration.Elapsed.Seconds));
                            //    recordDuration.Stop();

                            //    submission.StartBusinessRuleExecution();
                            //    context.SaveChanges();

                            //    var index = RunSystemBusinessRuleValidation(context,
                            //                                                submission,
                            //                                                submissionData,
                            //                                                totalBusinessRules,
                            //                                                totalDataRows,
                            //                                                0);
                            //    RunUserDefinedBusinessRuleValidation(context,
                            //                                            submission,
                            //                                            submissionData,
                            //                                            totalBusinessRules,
                            //                                            totalDataRows,
                            //                                            index);

                            //    if (submission.SubmissionStatusId != (int)SubmissionStatusEnum.FailedToImport &&
                            //        submission.SubmissionStatusId != (int)SubmissionStatusEnum.FailedToValidate)
                            //        submission.Complete();
                            //    context.SaveChanges();


                            //    //Execute Auto-Export functionality///////
                            //    if (submission.ExportTemplateId != null && submission.SubmissionStatusId != (int)SubmissionStatusEnum.FailedToValidate)
                            //    {
                            //        bool isRunAutoExport = true;

                            //        if (submission.IsAutoExportAfterRuleFails == false)
                            //        {
                            //            isRunAutoExport = true;
                            //        }
                            //        else
                            //        {
                            //            var faildresults = context.SubmissionResults.Where(x => x.SubmissionDataId == submission.CurrentSubmissionDataId &&
                            //                                                                  x.BusinessRuleId > 4 && x.IsValid == false).ToList();
                            //            if (faildresults.Count == 0)
                            //            {
                            //                isRunAutoExport = true;
                            //            }
                            //            else { isRunAutoExport = false; }
                            //        }


                            //        if (isRunAutoExport == true)
                            //        {
                            //            var exportDefination = context.ExportTemplates.FirstOrDefault(x => x.Id == submission.ExportTemplateId);
                            //            if (exportDefination != null)
                            //            {
                            //                exportDefination.LastExecutedOn = DateTime.Now;
                            //                context.SaveChanges();
                            //            }

                            //            var fileType = 20;

                            //            int contentType = exportDefination.ReportExportType == 1 ? 64 : 128;

                            //            var firewallRuleIds = new List<long>();
                            //            var submissionData_autoexport = context.SubmissionDatas.SingleOrDefault(x => x.Id == submission.CurrentSubmissionDataId);

                            //            if (!(submissionData_autoexport == null))
                            //            {

                            //                if (!((ExportFileTypeEnum)fileType == ExportFileTypeEnum.FixedWidth &&
                            //                    submissionData_autoexport.ExecutedWithDataSet.DataSetColumns.Any(x => x.Length == 0)))
                            //                {

                            //                    var submissionResultExport =
                            //                        context.SubmissionResultExports.SingleOrDefault(x => x.SubmissionDataId == submission.CurrentSubmissionDataId
                            //                                                                             && x.ExportContentTypeId == (int)contentType
                            //                                                                             && x.ExportFileTypeId == (int)fileType) ??
                            //                        new SubmissionResultExport { SubmissionData = submissionData };
                            //                    // var submissionResultExport = new SubmissionResultExport { SubmissionData = submissionData };

                            //                    var firewallRules = submissionData_autoexport.ExecutedWithDataSet.FirewallRules.Where(x => !firewallRuleIds.Contains(x.Id)).ToList();
                            //                    submissionResultExport.Queued((long)submission.CurrentSubmissionDataId, (ExportContentTypeEnum)contentType, (ExportFileTypeEnum)fileType, firewallRules, exportDefination.TableName, (int)submission.ExportTemplateId, false, "");
                            //                    var newRecord = submissionResultExport.Id == 0 ? context.SubmissionResultExports.Add(submissionResultExport) : submissionResultExport;
                            //                    context.SaveChanges();
                            //                }
                            //            }
                            //        }
                            //        //return newRecord.Id;  
                            //    }

                            //    //Execute Second Auto-Export functionality///////
                            //    if (submission.SecondExportTemplateId != null && submission.SubmissionStatusId != (int)SubmissionStatusEnum.FailedToValidate)
                            //    {
                            //        bool isRunAutoExport = true;

                            //        if (submission.IsAutoExportAfterRuleFails == false)
                            //        {
                            //            isRunAutoExport = true;
                            //        }
                            //        else
                            //        {
                            //            var faildresults = context.SubmissionResults.Where(x => x.SubmissionDataId == submission.CurrentSubmissionDataId &&
                            //                                                                  x.BusinessRuleId > 4 && (x.IsValid == true)).ToList();
                            //            if (faildresults.Count == 0)
                            //            {
                            //                isRunAutoExport = true;
                            //            }
                            //            else { isRunAutoExport = false; }
                            //        }


                            //        if (isRunAutoExport == true)
                            //        {
                            //            var exportDefination = context.ExportTemplates.FirstOrDefault(x => x.Id == submission.SecondExportTemplateId);
                            //            if (exportDefination != null)
                            //            {
                            //                exportDefination.LastExecutedOn = DateTime.Now;
                            //                context.SaveChanges();
                            //            }

                            //            var fileType = 20;

                            //            int contentType = exportDefination.ReportExportType == 1 ? 64 : 128;

                            //            var firewallRuleIds = new List<long>();
                            //            var submissionData_autoexport = context.SubmissionDatas.SingleOrDefault(x => x.Id == submission.CurrentSubmissionDataId);

                            //            if (!(submissionData_autoexport == null))
                            //            {

                            //                if (!((ExportFileTypeEnum)fileType == ExportFileTypeEnum.FixedWidth &&
                            //                    submissionData_autoexport.ExecutedWithDataSet.DataSetColumns.Any(x => x.Length == 0)))
                            //                {

                            //                    var submissionResultExport =
                            //                        context.SubmissionResultExports.SingleOrDefault(x => x.SubmissionDataId == submission.CurrentSubmissionDataId
                            //                                                                             && x.ExportContentTypeId == (int)contentType
                            //                                                                             && x.ExportFileTypeId == (int)fileType) ??
                            //                        new SubmissionResultExport { SubmissionData = submissionData };
                            //                    // var submissionResultExport = new SubmissionResultExport { SubmissionData = submissionData };

                            //                    var firewallRules = submissionData_autoexport.ExecutedWithDataSet.FirewallRules.Where(x => !firewallRuleIds.Contains(x.Id)).ToList();
                            //                    submissionResultExport.Queued((long)submission.CurrentSubmissionDataId, (ExportContentTypeEnum)contentType, (ExportFileTypeEnum)fileType, firewallRules, exportDefination.TableName, (int)submission.SecondExportTemplateId, false, "");
                            //                    var newRecord = submissionResultExport.Id == 0 ? context.SubmissionResultExports.Add(submissionResultExport) : submissionResultExport;
                            //                    context.SaveChanges();
                            //                }
                            //            }
                            //        }
                            //        //return newRecord.Id;  
                            //    }

                            //    ///////////////////////////////////////////////////////////////////
                            //    //// DETAILED SUBMISSION RESULTS FUNCTIONALITY.//////////////////// 
                            //    // var queryDetailsResults = BusinessRulesResultsDetailExportQueryableCopy(context, submission.CurrentSubmissionDataId.Value).ToList(); 

                            //    _log.Info(String.Format("Exporting detailed submission results to reports table started.."));

                            //    var res = context.PopulateDetailedSubmissionResults(submission.CurrentSubmissionDataId.Value);

                            //    _log.Info(String.Format("Exporting detailed submission results to reports table completed."));

                            //    ///////////////////////////////////////////////////////////////////
                            //}
                            _log.Info(String.Format("Expiry date {0}", expiryDate));
                            _log.Info(String.Format("Store database creation started...."));
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

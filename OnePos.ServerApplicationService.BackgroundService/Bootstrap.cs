using OnePos.ServerApplicationService;
using OnePos.Domain; 
using OnePos.Framework;
using OnePos.Framework.Domain;
using OnePos.Persistance;
using log4net;
using log4net.Config;

namespace OnePos.ServerApplicationService.BackgroundService
{
    public class Bootstrap
    {
        private readonly static ILog _log = LogManager.GetLogger(typeof(Bootstrap));

        private readonly IDependencyContainer _container = DependencyContainer.Default;

        public Bootstrap(IDependencyContainer container)
        {
            _container = container;
        }

        public void Initilise()
        {
            XmlConfigurator.Configure(); 
           
            _container.Register<IUniqueIdentifierGenerator, GuidCombGenerator>();
            _container.RegisterInstance<IOnePosEntitiesFactory>(new OnePosEntitiesFactory(_container));
            _container.Register<IOnePosEntities, OnePosEntities>();

            //_container.Register<IBusinessRuleExecutionService, BusinessRuleExecutionService>();
            //_container.Register<ISubmissionRepository, SubmissionRepository>();
            //_container.Register<ISubmissionResultExportRepository, SubmissionResultExportRepository>();
            //_container.Register<IImportingService, ImportingService>();
            //_container.Register<ISubmissionResultExportService, SubmissionResultExportService>();
            //_container.Register<IValidationResultHandler, ValidationResultHandler>(); 
            //_container.Register<IProfilingService, ProfilingService>(); 

            _log.Info("Bootstrap Initilised");
        }


    }
}

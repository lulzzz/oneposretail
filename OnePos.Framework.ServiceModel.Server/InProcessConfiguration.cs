using System;
using System.Collections.Generic;
using System.Reflection;
using OnePos.Framework.ServiceModel.Client;

namespace OnePos.Framework.ServiceModel.Server
{
	public class InProccessConfiguration
	{
		private readonly List<Assembly> _requestHandlerAssemblies = new List<Assembly>();
		private readonly List<Assembly> _requestsAndResponseAssemblies = new List<Assembly>();
		private readonly IDependencyContainer _container;
		private ServiceConfiguration _serviceConfiguration;

		public Type RequestProcessorImplementation { get; set; }
		public Type BusinessExceptionType { get; set; }
		public Type SecurityExceptionType { get; set; }

		public Type RequestDispatcherImplementation { get; set; }

		public InProccessConfiguration(IDependencyContainer container)
		{
			_container = container;
			SetDefaultImplementations();
		}


		public InProccessConfiguration(Assembly requestHandlersAssembly, Assembly requestsAndResponsesAssembly, IDependencyContainer container)
			: this(container)
		{
			AddRequestHandlerAssembly(requestHandlersAssembly);
			AddRequestAndResponseAssembly(requestsAndResponsesAssembly);
		}

		public InProccessConfiguration AddRequestHandlerAssembly(Assembly assembly)
		{
			_requestHandlerAssemblies.Add(assembly);
			return this;
		}

		public InProccessConfiguration AddRequestAndResponseAssembly(Assembly assembly)
		{
			_requestsAndResponseAssemblies.Add(assembly);
			return this;
		}

		private void SetDefaultImplementations()
		{
			RequestDispatcherImplementation = typeof(RequestDispatcher);
			RequestProcessorImplementation = typeof(RequestProcessor);
		}

		public void Initialize()
		{
			_serviceConfiguration = new ServiceConfiguration(_container)
			{
				BusinessExceptionType = BusinessExceptionType,
				RequestProcessorImplementation = RequestProcessorImplementation,
				SecurityExceptionType = SecurityExceptionType,
			};

			foreach (var assembly in _requestHandlerAssemblies)
				_serviceConfiguration.AddRequestHandlerAssembly(assembly);

			foreach (var assembly in _requestsAndResponseAssemblies)
				_serviceConfiguration.AddRequestAndResponseAssembly(assembly);

			_serviceConfiguration.Initialize();

			_container.Register(typeof(IRequestDispatcher), RequestDispatcherImplementation);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OnePos.Framework.ServiceModel.Server
{
	public class ServiceConfiguration
	{
		private readonly List<Assembly> _requestHandlerAssemblies = new List<Assembly>();
		private readonly List<Assembly> _requestsAndResponseAssemblies = new List<Assembly>();
		private readonly IDependencyContainer _container;
		
		public Type RequestProcessorImplementation { get; set; }
		public bool EnableUnitOfWorkOnService { get; set; }

		public Type BusinessExceptionType { get; set; }
		public Type SecurityExceptionType { get; set; }

		public ServiceConfiguration(IDependencyContainer container)
		{
			this._container = container;
			SetDefaultImplementations();
		}

		public ServiceConfiguration(Assembly requestHandlersAssembly, Assembly requestsAndResponsesAssembly, IDependencyContainer container)
			: this(container)
		{
			AddRequestHandlerAssembly(requestHandlersAssembly);
			AddRequestAndResponseAssembly(requestsAndResponsesAssembly);
		}

		public ServiceConfiguration AddRequestHandlerAssembly(Assembly assembly)
		{
			_requestHandlerAssemblies.Add(assembly);
			return this;
		}

		public ServiceConfiguration AddRequestAndResponseAssembly(Assembly assembly)
		{
			_requestsAndResponseAssemblies.Add(assembly);
			return this;
		}

		private void SetDefaultImplementations()
		{
			RequestProcessorImplementation = typeof(RequestProcessor);
		}

		public void Initialize()
		{
			_container.RegisterInstance(this);
			_container.Register(typeof(IRequestProcessor), RequestProcessorImplementation);

			RegisterRequestAndResponseTypes();
			RegisterRequestHandlers();
		}

		private void RegisterRequestAndResponseTypes()
		{
			foreach (var assembly in _requestsAndResponseAssemblies)
			{
				MessageKnownTypeProvider.RegisterDerivedTypesOf<Request>(assembly);
				MessageKnownTypeProvider.RegisterDerivedTypesOf<Response>(assembly);
			}
		}

		private void RegisterRequestHandlers()
		{
			var requestHandlerType = typeof(IRequestHandler<,>);

			foreach (var assembly in _requestHandlerAssemblies)
			{
				foreach (var type in assembly.GetTypes().Where(
					x => !x.IsAbstract && IsRequestHandler(x)))
				{
					foreach (Type requestHandlerTypeInterface in GetRequestHandlerInterfaces(type))
					{
						_container.Register(requestHandlerTypeInterface, type);
					}
				}
			}
		}

		private static IEnumerable<Type> GetRequestHandlerInterfaces(Type type)
		{
			return type.GetInterfaces().Where(i => i.Name.StartsWith("IRequestHandler"));
		}

		private static bool IsRequestHandler(Type type)
		{
			return type.GetInterfaces().Any(i => i.Name.StartsWith("IRequestHandler"));
		}

	}
}

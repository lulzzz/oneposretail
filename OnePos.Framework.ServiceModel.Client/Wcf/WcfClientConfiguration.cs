using System;
using System.Collections.Generic;
using System.Reflection;

namespace OnePos.Framework.ServiceModel.Client.Wcf
{
	public class WcfClientConfiguration
	{
		private readonly List<Assembly> _messageAssemblies = new List<Assembly>();
		private readonly IDependencyContainer _container;

		public Type RequestDispatcherImplementation { get; set; }
		public Func<IRequestProcessor> RequestProcessorFactory { get; set; }

		public WcfClientConfiguration(IDependencyContainer container)
		{
			this._container = container;
			SetDefaultImplementations();
		}
		
		public WcfClientConfiguration AddMessagesFromAssemblies(Assembly assembly)
		{
			_messageAssemblies.Add(assembly);
			return this;
		}

		private void SetDefaultImplementations()
		{
			RequestDispatcherImplementation = typeof(RequestDispatcher);
			RequestProcessorFactory = () => new WcfRequestProcessorProxy();
		}

		public void Initialize()
		{
			_container.RegisterFactoryFor<IRequestProcessor>(RequestProcessorFactory);
			_container.Register(typeof(IRequestDispatcher), RequestDispatcherImplementation);

			RegisterRequestAndResponseTypes();
		}

		private void RegisterRequestAndResponseTypes()
		{
			foreach (var assembly in _messageAssemblies)
			{
				MessageKnownTypeProvider.RegisterDerivedTypesOf<Request>(assembly);
				MessageKnownTypeProvider.RegisterDerivedTypesOf<Response>(assembly);
			}
		}
	}
}

using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using log4net;

namespace OnePos.Framework.ServiceModel.Server.Wcf
{
	public class ErrorLoggingBehaviorAttribute : Attribute, IServiceBehavior, IErrorHandler
	{
		private readonly ILog logger = LogManager.GetLogger(typeof(ErrorLoggingBehaviorAttribute));

		public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }

		public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }

		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
			foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
			{
				var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
				if (channelDispatcher != null)
				{
					channelDispatcher.ErrorHandlers.Add(this);
				}
			}
		}

		public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
		{
			logger.Error(error);
		}

		public bool HandleError(Exception error)
		{
			return false;
		}
	}
}

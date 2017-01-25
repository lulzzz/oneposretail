using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using OnePos.Framework.ServiceModel.Wcf;

namespace OnePos.Framework.ServiceModel.Client.Wcf
{
	public class WcfRequestProcessorProxy : ClientBase<IWcfRequestProcessor>, IRequestProcessor
	{
		public WcfRequestProcessorProxy() { }

		public WcfRequestProcessorProxy(string endpointConfigurationName) : base(endpointConfigurationName) { }

		public WcfRequestProcessorProxy(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress) { }

		public WcfRequestProcessorProxy(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress) { }

		public WcfRequestProcessorProxy(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) { }

		public WcfRequestProcessorProxy(InstanceContext callbackInstance) : base(callbackInstance) { }

		public WcfRequestProcessorProxy(InstanceContext callbackInstance, string endpointConfigurationName) : base(callbackInstance, endpointConfigurationName) { }

		public WcfRequestProcessorProxy(InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : base(callbackInstance, endpointConfigurationName, remoteAddress) { }

		public WcfRequestProcessorProxy(InstanceContext callbackInstance, string endpointConfigurationName, EndpointAddress remoteAddress) : base(callbackInstance, endpointConfigurationName, remoteAddress) { }

		public WcfRequestProcessorProxy(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress) : base(callbackInstance, binding, remoteAddress) { }

		public TResponse Process<TRequest, TResponse>(TRequest request) 
			where TRequest : Request 
			where TResponse : Response
		{
			return (TResponse)Channel.Process(request);
		}

		public void Dispose()
		{
			try
			{
				Close();
			}
			catch (Exception)
			{
				Abort();
			}
		}
	}
}

using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using OnePos.Framework.ServiceModel.Wcf;

namespace OnePos.Framework.ServiceModel.Server.Wcf
{
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	[ErrorLoggingBehavior]
	public class WcfRequestProcessor : IWcfRequestProcessor, IWcfRestJsonRequestProcessor, IWcfRestXmlRequestProcessor
	{
		[TransactionFlow(TransactionFlowOption.Allowed)]
		public Response Process(Request request)
		{
			using (var processor = DependencyContainer.Default.Resolve<IRequestProcessor>())
			{
				Response response;

				try
				{
					var processMethod = processor.GetType().GetMethod("Process");
					var genericArguments = new Type[] { request.GetType(), Type.GetType(request.ResponseType) };
					var genericProcessMethod = processMethod.MakeGenericMethod(genericArguments);
					response = (Response)genericProcessMethod.Invoke(processor, new object[] { request });
				}
				finally
				{
					DependencyContainer.Default.Release(request);
				}

				return response;
			}
		}
	}
}

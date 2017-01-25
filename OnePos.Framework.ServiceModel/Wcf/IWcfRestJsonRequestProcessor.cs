using System.ServiceModel;
using System.ServiceModel.Web;

namespace OnePos.Framework.ServiceModel.Wcf
{
	[ServiceContract]
	public interface IWcfRestJsonRequestProcessor
	{
		[OperationContract(Name = "ProcessJsonRequests")]
		[ServiceKnownType("GetKnownTypes", typeof(MessageKnownTypeProvider))]
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedResponse, Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response Process(Request request);

	}
}

using System.ServiceModel;
using System.ServiceModel.Web;

namespace OnePos.Framework.ServiceModel.Wcf
{
	[ServiceContract]
	public interface IWcfRestXmlRequestProcessor
	{
		[OperationContract(Name = "ProcessXmlRequests")]
		[ServiceKnownType("GetKnownTypes", typeof(MessageKnownTypeProvider))]
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
		Response Process(Request requests);
	}
}

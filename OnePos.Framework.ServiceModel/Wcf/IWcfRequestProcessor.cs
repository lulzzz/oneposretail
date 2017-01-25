using System.ServiceModel;

namespace OnePos.Framework.ServiceModel.Wcf
{
	[ServiceContract]
	public interface IWcfRequestProcessor
	{
		[OperationContract(Name = "ProcessRequests")]
		[ServiceKnownType("GetKnownTypes", typeof(MessageKnownTypeProvider))]
		Response Process(Request requests);
	}
}

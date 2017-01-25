using System.Runtime.Serialization;

namespace OnePos.Framework.ServiceModel
{
	[DataContract]
	public abstract class Request
	{
        [DataMember]
        public string ResponseType { get; set; }
	}
}

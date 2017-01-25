namespace OnePos.Framework.ServiceModel.Server
{
	public interface IRequestHandler<TRequest, TResponse> 
		where TRequest : Request
		where TResponse : Response
	{
		TResponse Handle(TRequest request);
	}
}

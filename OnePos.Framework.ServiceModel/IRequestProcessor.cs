using System;

namespace OnePos.Framework.ServiceModel
{
	public interface IRequestProcessor : IDisposable
	{
		TResponse Process<TRequest, TResponse>(TRequest request) 
			where TRequest : Request
			where TResponse : Response;
	}
}

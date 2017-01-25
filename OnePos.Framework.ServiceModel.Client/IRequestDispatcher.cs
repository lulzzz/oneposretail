using System;

namespace OnePos.Framework.ServiceModel.Client
{
	public interface IRequestDispatcher : IDisposable
	{
		TResponse Get<TRequest, TResponse>(TRequest request)
			where TRequest : Request
			where TResponse : Response;

		RequestDispatcherAsyncResult<TResponse> BeginGet<TRequest, TResponse>(TRequest request, AsyncCallback callback, object asyncState)
			where TRequest : Request
			where TResponse : Response;

		TResponse EndGet<TResponse>(IAsyncResult result)
			where TResponse : Response;

	}

}

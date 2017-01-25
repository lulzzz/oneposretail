using System;
using log4net;

namespace OnePos.Framework.ServiceModel.Client
{
	public class RequestDispatcher : Disposable, IRequestDispatcher
	{
        private readonly IRequestProcessor _requestProcessor;
        private readonly ILog logger = LogManager.GetLogger(typeof(RequestDispatcher));

		public RequestDispatcher(IRequestProcessor requestProcessor)
		{
			_requestProcessor = requestProcessor;
		}

		public TResponse Get<TRequest, TResponse>(TRequest request)
			where TRequest : Request
			where TResponse : Response
		{
			// Sets the response type so the server can determin the correct message hander to invoke
			request.ResponseType = string.Format("{0}, {1}", typeof(TResponse).FullName, typeof(TResponse).Assembly.FullName);

			var response = _requestProcessor.Process<TRequest, TResponse>(request);
			DealWithPossibleExceptions(response);
			return response;
		}

		public RequestDispatcherAsyncResult<TResponse> BeginGet<TRequest, TResponse>(TRequest request, AsyncCallback callback, object asyncState)
			where TRequest : Request
			where TResponse : Response
		{
			return new RequestDispatcherAsyncResult<TResponse>(() => Get <TRequest, TResponse>(request),
					callback,
					asyncState);
		}

		public TResponse EndGet<TResponse>(IAsyncResult result) where TResponse : Response
		{
			var customAsyncResult = result as RequestDispatcherAsyncResult<TResponse>;
			if (customAsyncResult == null)
				throw new ArgumentException();
			return customAsyncResult.Result();
		}

		protected override void DisposeManagedResources()
		{
			if (_requestProcessor != null) _requestProcessor.Dispose();
		}

		private void DealWithPossibleExceptions(Response response)
		{
			if (response.ExceptionType == ExceptionType.Security)
			{
				DealWithSecurityException(response.Exception);
			}

			if (response.ExceptionType == ExceptionType.Unknown)
			{
				DealWithUnknownException(response.Exception);
			}

            if (response.ExceptionType != ExceptionType.None)
            {
                var exception = new Exception(String.Format("ExceptionType:{0}/r/nMessage:{1}/r/nInner Exception:{2}", response.ExceptionType.ToString(), response.Exception.Message, response.Exception.InnerException));
                logger.Error("DealWithPossibleExceptions", exception);
            }
		}

		protected virtual void DealWithUnknownException(ExceptionInfo exception) { }

		protected virtual void DealWithSecurityException(ExceptionInfo exceptionDetail) { }
	}
}

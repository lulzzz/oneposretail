using System;
using log4net;

namespace OnePos.Framework.ServiceModel.Server
{
	public class RequestProcessor : Disposable, IRequestProcessor
	{
		private readonly ServiceConfiguration _serviceConfiguration;
		private readonly ILog logger = LogManager.GetLogger(typeof(RequestProcessor));

		protected override void DisposeManagedResources()
		{
			// empty by default but you should override this in derived classes so you can clean up your resources
		}

		public RequestProcessor(ServiceConfiguration serviceConfiguration) //ICacheManager cacheManager)
		{
			_serviceConfiguration = serviceConfiguration;
		}

		public TResponse Process<TRequest, TResponse>(TRequest request)
			where TRequest : Request
			where TResponse : Response
		{
		    var handler = DependencyContainer.Default.Resolve(GetRequestHandlerTypeFor(typeof(TRequest), typeof(TResponse)));
            if (handler == null) throw new ApplicationException(string.Format("Unable to find handler for request {0}", request.GetType()));

            TResponse response = GetResponseFromHandler<TRequest, TResponse>(request, handler);
            DependencyContainer.Default.Release(handler);

		    return response;

		    //IUnitOfWork unitOfWork = null;

		    //if( _serviceConfiguration.EnableUnitOfWorkOnService )
		    //    unitOfWork = DependencyContainer.Default.Resolve<IUnitOfWork>();

		    //try
		    //{
		    //    if (unitOfWork != null)
		    //        unitOfWork.Initialise();

		    //    var handler = DependencyContainer.Default.Resolve(GetRequestHandlerTypeFor(typeof(TRequest), typeof(TResponse)));
		    //    try
		    //    {
		    //        response = GetResponseFromHandler<TRequest, TResponse>(request, handler);

		    //        if (unitOfWork != null)
		    //        {
		    //            if (response.ExceptionType != ExceptionType.None)
		    //                unitOfWork.Rollback();
		    //            else
		    //                unitOfWork.Commit();
		    //        }

		    //    }
		    //    finally
		    //    {
		    //        if( handler != null )
		    //            DependencyContainer.Default.Release(handler);
		    //    }

		    //}
		    //catch (Exception e)
		    //{
		    //    if (unitOfWork != null)
		    //        unitOfWork.Rollback();

		    //    logger.Error(e);
		    //    throw;
		    //}
		    //finally
		    //{
		    //    if (unitOfWork != null)
		    //        DependencyContainer.Default.Release(unitOfWork);
		    //}

		    //return response;
		}

		private static Type GetRequestHandlerTypeFor(Type requestType, Type responseType)
		{
			// get a type reference to IRequestHandler<TRequest, TResponse>
			return typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);
		}

		private TResponse GetResponseFromHandler<TRequest, TResponse>(TRequest request, object handler)
			where TRequest : Request
			where TResponse : Response
		{
		    try
		    {
		    	var methodInfo = handler.GetType().GetMethod("Handle");
				return (TResponse)methodInfo.Invoke(handler, new object[] { request });
		    }
		    catch (Exception e)
		    {
		        OnHandlerException(request, e.GetBaseException());
                return (TResponse)CreateExceptionResponse(typeof(TResponse), e.GetBaseException());
		    }
		}

		protected virtual void OnHandlerException(Request request, Exception exception)
		{
			logger.Error("RequestProcessor: unhandled exception while handling request!", exception);
		}

		protected virtual Response CreateExceptionResponse(Type responseType, Exception exception)
		{
			var response = (Response)Activator.CreateInstance(responseType);
			response.Exception = new ExceptionInfo(exception);
			SetExceptionType(response, exception);
			return response;
		}

		private void SetExceptionType(Response response, Exception exception)
		{
			var exceptionType = exception.GetType();

			if (exceptionType.Equals(_serviceConfiguration.BusinessExceptionType))
			{
				response.ExceptionType = ExceptionType.Business;
				return;
			}

			if (exceptionType.Equals(_serviceConfiguration.SecurityExceptionType))
			{
				response.ExceptionType = ExceptionType.Security;
				return;
			}

			response.ExceptionType = ExceptionType.Unknown;
		}
	}
}

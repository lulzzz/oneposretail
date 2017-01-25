using System;
using System.Threading;

namespace OnePos.Framework.ServiceModel.Client
{
	public class RequestDispatcherAsyncResult<T> : IAsyncResult
	{
		private volatile Boolean _isCompleted;
		private ManualResetEvent _evt;
		private readonly AsyncCallback _callBackMethod;
		private readonly Object _state;
		private T _result;
		private Exception _exception;


		public RequestDispatcherAsyncResult(Func<T> workToBeDone, AsyncCallback callBackMethod, Object state)
		{
			_callBackMethod = callBackMethod;
			_state = state;
			QueueWorkOnThreadPool(workToBeDone);
		}

		private void QueueWorkOnThreadPool(Func<T> workToBeDone)
		{
			ThreadPool.QueueUserWorkItem(state =>
			{
				try
				{
					_result = workToBeDone();
				}
				catch (Exception ex)
				{
					_exception = ex;
				}
				finally
				{
					UpdateStatusToComplete(); //1 and 2 
					NotifyCallbackWhenAvailable(); //3 callback invocation 
				}
			});
		}

		public T Result()
		{
			if (!_isCompleted)
			{
				AsyncWaitHandle.WaitOne();
				AsyncWaitHandle.Close();
			}
			if (_exception != null)
			{
				throw _exception;
			}
			return _result;
		}

		private void NotifyCallbackWhenAvailable()
		{
			if (_callBackMethod != null)
			{
				_callBackMethod(this);
			}
		}

		public object AsyncState
		{
			get { return _state; }
		}

		public WaitHandle AsyncWaitHandle
		{
			get { return GetEvtHandle(); }
		}

		public bool CompletedSynchronously
		{
			get { return false; }
		}

		public bool IsCompleted
		{
			get { return _isCompleted; }
		}

		private readonly Object _locker = new Object();
		private ManualResetEvent GetEvtHandle()
		{
			lock (_locker)
			{
				if (_evt == null)
				{
					_evt = new ManualResetEvent(false);
				}
				if (_isCompleted)
				{
					_evt.Set();
				}
			}
			return _evt;
		}

		private void UpdateStatusToComplete()
		{
			_isCompleted = true; //1. set _iscompleted to true 
			lock (_locker)
			{
				if (_evt != null)
				{
					_evt.Set(); //2. set the event, when it exists 
				}
			}
		}
	}
}

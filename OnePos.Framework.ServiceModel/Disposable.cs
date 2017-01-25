using System;

namespace OnePos.Framework.ServiceModel
{
	public abstract class Disposable : IDisposable
	{
		private bool _isDisposed;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public bool IsDisposed
		{
			get { return _isDisposed; }
		}

		protected void Dispose(bool disposing)
		{
			if (!IsDisposed)
			{
				if (disposing)
				{
					DisposeManagedResources();
				}

				DisposeUnmanagedResources();
				_isDisposed = true;
			}
		}

		protected void ThrowExceptionIfDisposed()
		{
			if (IsDisposed)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
		}

		protected abstract void DisposeManagedResources();
		protected virtual void DisposeUnmanagedResources() { }
	}
}

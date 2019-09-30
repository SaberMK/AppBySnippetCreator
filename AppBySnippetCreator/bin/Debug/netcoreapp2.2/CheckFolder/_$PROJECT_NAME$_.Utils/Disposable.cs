using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Utils
{
    public abstract class Disposable : IDisposable
    {
        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
                DisposeCore();

            IsDisposed = true;
        }
        protected abstract void DisposeCore();
        protected bool IsDisposed { get; private set; }
    }
}

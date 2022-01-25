using System;

namespace TOS.Common
{
    public abstract class Disposable : IDisposable
    {
        protected Disposable()
        {

        }

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);
    }
}

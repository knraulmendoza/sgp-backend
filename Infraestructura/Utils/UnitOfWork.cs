using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Utils
{
    public class UnitOfWork : IDisposable
    {
        private readonly SgpContext context = new SgpContext();

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Wahid.HMS.Core.Abstract;

namespace Wahid.HMS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool isDisposed = false;
        public string ReturnString(string str) { return str; }
        public void Dispose(bool disposing)
        {
            if (!isDisposed) return;
            if (disposing)
            {
                //free managed resources
            }

            //free unmanaged resources
            isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

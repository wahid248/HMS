using System;
using System.Collections.Generic;
using System.Text;
using Wahid.HMS.Core.Abstract;
using Wahid.HMS.Core.Abstract.Repositories;

namespace Wahid.HMS.Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool isDisposed = false;

        public IPatientRepository PatientRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

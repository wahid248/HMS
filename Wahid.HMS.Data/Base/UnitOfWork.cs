using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wahid.HMS.Core.Abstract;
using Wahid.HMS.Core.Abstract.Repositories;
using Wahid.HMS.Data.Repositories;

namespace Wahid.HMS.Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;
        private bool isDisposed = false;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

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
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }

        

        public IPatientRepository PatientRepository => new PatientRepository(_context);
    }
}

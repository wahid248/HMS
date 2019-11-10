using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wahid.HMS.Core.Abstract;
using Wahid.HMS.Core.Abstract.Repositories;
using Wahid.HMS.Data.Repositories;

namespace Wahid.HMS.Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DataContext _context;
        private bool isDisposed = false;

        public UnitOfWork(DataContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Dispose(bool disposing)
        {
            if (!isDisposed) return;
            if (disposing)
            {
                //free managed resources
                this.Dispose();
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
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        

        public IPatientRepository PatientRepository => new PatientRepository(_context);
    }
}

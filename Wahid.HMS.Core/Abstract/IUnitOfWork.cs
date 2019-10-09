using System;
using Wahid.HMS.Core.Abstract.Repositories;

namespace Wahid.HMS.Core.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        void SaveChangesAsync();
        IPatientRepository PatientRepository { get; }
    }
}

using System;
using System.Threading.Tasks;
using Wahid.HMS.Core.Abstract.Repositories;

namespace Wahid.HMS.Core.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        Task SaveChangesAsync();
        IPatientRepository PatientRepository { get; }
    }
}

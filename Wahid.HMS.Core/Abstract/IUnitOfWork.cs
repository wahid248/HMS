using System;
using System.Collections.Generic;
using System.Text;
using Wahid.HMS.Core.Abstract.Repositories;

namespace Wahid.HMS.Core.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        public IPatientRepository PatientRepository { get; set; }
    }
}

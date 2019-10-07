using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wahid.HMS.Core.Entities;
using Wahid.HMS.Data.Base;

namespace Wahid.HMS.Data.Repositories
{
    public class PatientRepository : Repository<Patient, long>
    {
        public PatientRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wahid.HMS.Core.Entities;

namespace Wahid.HMS.Data.Base
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public virtual DbSet<Patient> Patients { get; set; }
    }
}

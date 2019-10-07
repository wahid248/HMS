using System;
using System.Collections.Generic;
using System.Text;

namespace Wahid.HMS.Core.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        public string ReturnString(string str);
    }
}

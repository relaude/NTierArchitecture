using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        IContext Context { get; }
    }
}

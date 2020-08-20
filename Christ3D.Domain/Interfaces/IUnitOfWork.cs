using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        bool Commit();
    }
}

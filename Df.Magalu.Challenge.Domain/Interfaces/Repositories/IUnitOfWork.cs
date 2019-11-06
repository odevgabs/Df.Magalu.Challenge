using System;
using System.Collections.Generic;
using System.Text;

namespace Df.Magalu.Challenge.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        bool Commit();
        void Dispose();
    }
}

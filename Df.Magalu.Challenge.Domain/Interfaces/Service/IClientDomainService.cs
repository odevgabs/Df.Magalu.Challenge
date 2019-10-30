using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Domain.Interfaces.Service
{
    public interface IClientDomainService
    {
        Task<IClient> Create(string name, string email);
    }
}

using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Service.Requests.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Service.Interfaces
{
    public interface IClientService
    {
        Task<IClient> Create(ClientCreateRequest request);
    }
}

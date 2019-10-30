using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Domain.Service
{
    public class ClientDomainService : IClientDomainService
    {
        private readonly IClientFactory _clientFactory;

        public ClientDomainService(IClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IClient> Create(string name, string email)
        {
            IClient client = _clientFactory.Create(name, email);
            return client;
        }
    }
}

using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Service;
using Df.Magalu.Challenge.Service.Interfaces;
using Df.Magalu.Challenge.Service.Requests.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Service
{
    public class ClientService : IClientService
    {

        private readonly IClientDomainService _clientDomainService;
        public ClientService(IClientDomainService clientDomainService)
        {
            this._clientDomainService = clientDomainService;
        }

        public async Task<IClient> Create(ClientCreateRequest request)
        {
            IClient client = await _clientDomainService.Create(request.Name, request.Email);
            return client;
        }
    }
}

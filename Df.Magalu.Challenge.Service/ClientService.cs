using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
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
        private readonly IClientFactory _clientFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientRepository _clientRepository;


        public ClientService(IClientFactory clientFactory, IUnitOfWork unitOfWork, IClientRepository clientRepository)
        {
            _clientFactory = clientFactory;
            _unitOfWork = unitOfWork;
            _clientRepository = clientRepository;
        }

        public async Task<IClient> Create(ClientCreateRequest request)
        {
            IClient client = _clientFactory.Create(request.Name, request.Email);
            _clientRepository.Create(client);

            await _unitOfWork.CommitAsync().ConfigureAwait(false);
            
            return client;
        }
    }
}

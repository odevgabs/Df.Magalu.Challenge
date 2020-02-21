using Df.Magalu.Challenge.Domain.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
using Df.Magalu.Challenge.Service.Interfaces;
using Df.Magalu.Challenge.Service.Requests.Client;
using Df.Message.Broker.ServiceBus.Contracts;
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
        private readonly IPublisher<IClient> _publisher;


        public ClientService(IClientFactory clientFactory, IUnitOfWork unitOfWork, IClientRepository clientRepository, IPublisher<IClient>  publisher)
        {
            _clientFactory = clientFactory;
            _unitOfWork = unitOfWork;
            _clientRepository = clientRepository;
            _publisher = publisher;
        }

        public async Task<IClient> Create(ClientCreateRequest request)
        {
            IClient client = _clientFactory.Create(request.Name, request.Email);
            _clientRepository.Create(client);

            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            Client client1 = new Client("teste", "teste");

            object p = await _publisher.SendMessagesAsync(client1);

            return client;
        }
    }
}

using Df.Magalu.Challenge.Domain.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Service;
using Df.Magalu.Challenge.Domain.Service;
using Df.Magalu.Challenge.Service;
using Df.Magalu.Challenge.Service.Interfaces;
using Df.Magalu.Challenge.Service.Requests.Client;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Tests.Service
{
    public class ClientServiceTests
    {
        private IClientFactory _clientFactory;
        private IClientDomainService _clientDomainService;
        private IClientService _clientService;

        [SetUp]
        public void Setup()
        {
            _clientFactory = new ClientFactory();
            _clientDomainService = new ClientDomainService(_clientFactory);
            _clientService = new ClientService(_clientDomainService);
        }

        static IEnumerable<object[]> clientCreateRequestValid()
        {
            ClientCreateRequest clientCreateRequest = new ClientCreateRequest()
            {
                Email = "grfgabriel.ti@gmail.com",
                Name = "Gabriel Rodrigues"
            };
            return new[] { new object[] {clientCreateRequest } };
        }

        [Test, TestCaseSource("clientCreateRequestValid")]
        public async Task ShouldCreateIClient(ClientCreateRequest clientCreateRequest)
        {
            IClient client = await _clientService.Create(clientCreateRequest);
            client.Name.Should().Be(clientCreateRequest.Name);
            client.Email.Should().Be(clientCreateRequest.Email);
        }
    }
}

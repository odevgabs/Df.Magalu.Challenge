using Df.Magalu.Challenge.Domain.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Service;
using Df.Magalu.Challenge.Domain.Service;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Tests.DomainService
{
    public class ClientDomainServiceTests
    {

        private IClientDomainService _clientDomainService;
        private IClientFactory _clientFactory;


        [SetUp]
        public void Setup()
        {
            _clientFactory = new ClientFactory();
            _clientDomainService = new ClientDomainService(_clientFactory);
        }

        [Test]
        [TestCase("Gabriel Rodrigues", "grfgabriel.ti@gmail.com")]
        public async Task ShouldCreateIClient(string name, string email)
        {
            IClient client = await _clientDomainService.Create(name, email);
            client.Name.Should().Be(name);
            client.Email.Should().Be(email);
        }

        [Test]
        [TestCase("nameClient", "")]
        [TestCase("", "emailCleinte")]
        [TestCase("", "")]
        public async Task ShouldNotCreateClient(string nameClient, string emailCliente)
        {
            Func<IClient> cliente = () => _clientDomainService.Create(nameClient, emailCliente)
                                                                        .GetAwaiter().GetResult();
            cliente.Should().Throw<ArgumentException>();
        }
    }
}

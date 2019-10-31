using Df.Magalu.Challenge.Domain.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Factories;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Df.Magalu.Challenge.Tests.Factories
{
    public class ClientFactoryTests
    {
        private IClientFactory _clientFactory;
        
        [SetUp]
        public void Setup()
        {
            _clientFactory = new ClientFactory();
        }

        [Test]
        [TestCase("Gabriel Rodrigues", "grfgabriel.ti@gmail.com")]
        public void ShouldCreateIClient(string name, string email)
        {
            IClient client = _clientFactory.Create(name, email);
            client.Name.Should().Be(name);
            client.Email.Should().Be(email);
        }

        [Test]
        [TestCase("nameClient", "")]
        [TestCase("", "emailCleinte")]
        [TestCase("", "")]
        public void ShouldNotCreateClient(string nameClient, string emailCliente)
        {
            Func<IClient> cliente = () => _clientFactory.Create(nameClient, emailCliente);
            cliente.Should().Throw<ArgumentException>();
        }
    }
}

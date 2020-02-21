using Df.Magalu.Challenge.Data;
using Df.Magalu.Challenge.Data.Context;
using Df.Magalu.Challenge.Domain.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
using Df.Magalu.Challenge.Service;
using Df.Magalu.Challenge.Service.Interfaces;
using Df.Magalu.Challenge.Service.Requests.Client;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
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
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IClientRepository> _clientRepositoryMock;
        private Mock<IConfiguration> _configurationMock;
        private IClientService _clientService;

        [SetUp]
        public void Setup()
        {
            _clientFactory = new ClientFactory();

            _configurationMock = new Mock<IConfiguration>();
            _configurationMock.Setup(x => x.GetSection(It.IsAny<string>()).GetSection(It.IsAny<string>()).Value).Returns("mongodb://localhost:27017");


            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _clientRepositoryMock = new Mock<IClientRepository>();

            //_clientService = new ClientService(_clientFactory, _unitOfWorkMock.Object, _clientRepositoryMock.Object);
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
            _unitOfWorkMock.Setup(x => x.CommitAsync()).Returns(Task.FromResult(true));

            IClient client = await _clientService.Create(clientCreateRequest);
            client.Name.Should().Be(clientCreateRequest.Name);
            client.Email.Should().Be(clientCreateRequest.Email);
            _unitOfWorkMock.VerifyAll();
        }
    }
}

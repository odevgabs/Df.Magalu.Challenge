using Df.Magalu.Challenge.Data.Context;
using Df.Magalu.Challenge.Domain.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Factories;
using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Tests.Repository
{
    public class MongoContextTests
    {
        private IMongoContext _mongoContext;
        private Mock<IMongoCollection<IClient>> _mongoCollectionMock;
        private Mock<IConfiguration> _configurationMock;
        private Mock<IMongoDatabase> _mongoDataBaseMock;
        private Mock<IMongoClient> _mongoClient;
        private IClientFactory _clientFactory;
        [SetUp]
        public void Setup()
        {
            _mongoClient = new Mock<IMongoClient>();
            _mongoDataBaseMock = new Mock<IMongoDatabase>();

            _configurationMock = new Mock<IConfiguration>();
            _configurationMock.Setup(x => x.GetSection(It.IsAny<string>()).GetSection(It.IsAny<string>()).Value).Returns("mongodb://localhost:27017");

            _mongoCollectionMock = new Mock<IMongoCollection<IClient>>();
            _mongoContext = new MongoContext(_configurationMock.Object);

            _clientFactory = new ClientFactory();
        }

        public async Task Success()
        {
            await Task.Run(() => new { Success = true });
        }

        [Test]
        public void ShouldAddCommand()
        {
            _mongoContext.AddCommand(async () => { await Success(); });
            _mongoContext._commands.Count.Should().BePositive();
            _mongoContext._commands.Count.Should().Be(1);
        }

        [Test]
        public void ShouldGetCollection()
        {
            var result = _mongoContext.GetCollection<IClient>("IClient");
            result.Should().NotBeNull();
        }

        [Test] 
        public async Task SouldSaveChanges()
        {
            //_mongoClient.Setup(x => x.StartSessionAsync().GetAwaiter().GetResult());

            _mongoContext.AddCommand(async () => { await Success(); });
            int result = await _mongoContext.SaveChanges();
            result.Should().Be(1);
        }
    }
}

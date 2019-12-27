using AutoMapper;
using Df.Magalu.Challenge.Acl;
using Df.Magalu.Challenge.Domain.Dto;
using Df.Magalu.Challenge.Domain.Entity;
using FluentAssertions;
using Flurl.Http.Testing;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Tests.Acl
{
    public class ProductLabsAclTest
    {
        private HttpTest _httpTest;
        private ProductLabsAcl _productLabsAcl;
        private Mock<IConfiguration> _configurationMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _configurationMock = new Mock<IConfiguration>();
            _mapperMock = new Mock<IMapper>();
            _mapperMock.Setup(m => m.Map<Product>(It.IsAny<ProductLabsDto>())).Returns(new Product());
            _configurationMock.Setup(x => x.GetSection("ApiLuizaLabsBase").Value).Returns("http://challenge-api.luizalabs.com/api/");

            _productLabsAcl = new ProductLabsAcl(_configurationMock.Object, _mapperMock.Object);
            _httpTest = new HttpTest();
        }

        [TearDown]
        public void DisposeHttpTest()
        {
            _httpTest.Dispose();
        }

        [Test]
        [TestCase("1bf0f365-fbdd-4e21-9786-da459d78dd1f")]
        public async Task ShouldReturnProductById(Guid productId)
        {
            var result = await _productLabsAcl.GetProductById(productId);

            result.Should().NotBeNull();
            _mapperMock.VerifyAll();
        }
    }
}

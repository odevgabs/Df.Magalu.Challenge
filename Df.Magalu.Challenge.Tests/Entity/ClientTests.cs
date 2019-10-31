using Df.Magalu.Challenge.Domain.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Df.Magalu.Challenge.Tests.Entity
{
    public class ClientTests
    {
        static IEnumerable<object[]> ClientWithProduct()
        {
            Product product = new Product();
            return new[] { new object[] { "Gabriel Rodrigues", "grfgabriel.ti@gmail.com", product } };
        }

        [Test]
        [TestCase("Gabriel Rodrigues", "grfgabriel.ti@gmail.com")]
        public void ShouldCreateClient(string nameClient, string emailCliente)
        {
            IClient client = new Client(nameClient, emailCliente);

            client._id.Should().NotBeEmpty();
            client.CreationDate.Should().NotBeOnOrAfter(DateTime.Now);
            client.Name.Should().Be(nameClient);
            client.Email.Should().Be(emailCliente);
        }

        [Test]
        [TestCase("nameClient", "")]
        [TestCase("", "emailCleinte")]
        [TestCase("", "")]
        public void ShouldNotCreateClient(string nameClient, string emailCliente)
        {
            Func<IClient> cliente = () => new Client(nameClient, emailCliente);
            cliente.Should().Throw<ArgumentException>();
        }

        [Test, TestCaseSource("ClientWithProduct")]
        public void ShouldAddProduct(string nameClient, string emailCliente, Product product)
        {
            IClient client = new Client(nameClient, emailCliente);
            client.AddFavoriteProduct(product);

            client.FavoritesProducts.Count.Should().Be(1);
            client.FavoritesProducts.Should().NotBeNull();
        }
    }
}

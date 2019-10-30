using Df.Magalu.Challenge.Domain.Entity;
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
            Client client = new Client(nameClient, emailCliente);

            client.Name.Should().Be(nameClient);
            client.Email.Should().Be(emailCliente);
        }

        [Test]
        [TestCase("nameClient", "")]
        [TestCase("", "emailCleinte")]
        [TestCase("", "")]
        public void ShouldNotCreateClient(string nameClient, string emailCliente)
        {
            Func<Client> cliente = () => new Client(nameClient, emailCliente);
            cliente.Should().Throw<ArgumentException>();
        }

        [Test, TestCaseSource("ClientWithProduct")]
        public void ShouldAddProduct(string nameClient, string emailCliente, Product product)
        {
            Client client = new Client(nameClient, emailCliente);
            client.AddProduct(product);

            client.Products.Count.Should().Be(1);
            client.Products.Should().NotBeNull();
        }
    }
}

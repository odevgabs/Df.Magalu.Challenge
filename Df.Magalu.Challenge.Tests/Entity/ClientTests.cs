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
        [Test]
        public void ShouldCreateClient()
        {
            string nameClient = "Gabriel Rodrigues";
            string emailCliente = "grfgabriel.ti@gmail.com";

            Client client = new Client(nameClient, emailCliente);

            client.Name.Should().Be(nameClient);
            client.Email.Should().Be(emailCliente);
        }

        [Test]
        public void ShouldAddProduct()
        {
            string nameClient = "Gabriel Rodrigues";
            string emailCliente = "grfgabriel.ti@gmail.com";


            Product product = new Product();
            Client client = new Client(nameClient, emailCliente);
            client.AddProduct(product);

            client.Products.Count.Should().Be(1);
            client.Products.Should().NotBeNull();
        }


    }
}

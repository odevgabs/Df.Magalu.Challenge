
using System;
using Df.Magalu.Challenge.Domain.ValueObject;
using NUnit.Framework;
using FluentAssertions;

namespace Df.Magalu.Challenge.Tests.ValueObject
{
    public class ProductTest
    {
        [Test]
        public void ShouldCreateProduct()
        {
            decimal price = 14.30M;
            string image = "https://cdn.meutimao.com.br/_upload/idolos-do-corinthians/vampeta.jpg";
            string brand = "Corinthians";
            Guid id = Guid.NewGuid();
            string title = "product mock";
            string reviewScore = "";

            Product product = new Product(price, image, brand, id,title, reviewScore);

            product.Price.Should().Be(price);
            product.Image.Should().Be(image);
            product.Brand.Should().Be(brand);
            product.Id.Should().Be(id);
            product.Title.Should().Be(title);
            product.ReviewScore.Should().Be(reviewScore);
        }

    }
}
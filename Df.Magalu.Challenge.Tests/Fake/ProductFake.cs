using System;
using Df.Magalu.Challenge.Domain.ValueObject;

namespace Df.Magalu.Challenge.Tests.Fake
{
    public static class ProductFake
    {
        public static Product Create()
        {
            decimal price = 14.30M;
            string image = "https://cdn.meutimao.com.br/_upload/idolos-do-corinthians/vampeta.jpg";
            string brand = "Corinthians";
            Guid id = Guid.NewGuid();
            string title = "product mock";
            string reviewScore = "";

            Product product = new Product(price, image, brand, id,title, reviewScore);

            return product;
        }
        
    }
}
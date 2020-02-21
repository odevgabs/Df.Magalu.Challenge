using System;

namespace Df.Magalu.Challenge.Domain.ValueObject
{
    public class Product
    {
        public Product (decimal price, string image, string brand, Guid id, string title, string reviewScore)
        {
            Price = price;
            Image = image;
            Brand = brand;
            Id = id;
            Title = title;
            ReviewScore =reviewScore;
        }

        public decimal Price { get; private set; }
        public string Image { get; private set; }
        public string Brand { get; private set; }
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string ReviewScore { get; private set; }
    }
}
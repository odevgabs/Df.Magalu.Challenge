using System;
using System.Collections.Generic;
using System.Text;

namespace Df.Magalu.Challenge.Domain.Entity
{
    public class Product
    {
        public decimal Price { get; private set; }
        public string Image { get; private set; }
        public string Brand { get; private set; }
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string ReviewScore { get; private set; }

        public Product()
        { 
        
        }


    }
}

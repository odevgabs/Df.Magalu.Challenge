using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.ValueObject;
using System;
using System.Collections.Generic;

namespace Df.Magalu.Challenge.Domain.Entity
{
    public class Client : IEntity, IClient
    {
        public Guid _id { get; private set; }
        public DateTime CreationDate { get; private set; }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public List<Product> FavoritesProducts { get; private set; }


        public Client(string name, string email)
        {
            _id = Guid.NewGuid();
            CreationDate = DateTime.Now;

            DefineNome(name);
            DefineEmail(email);
            FavoritesProducts = new List<Product>();
        }
        public void DefineNome(string name)
        {

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name is Null or Empty");

            this.Name = name;
        }
        public void DefineEmail(string email)
        {

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("email is Null or Empty");

            this.Email = email;
        }
        public void AddFavoriteProduct(Product product)
        {
            this.FavoritesProducts.Add(product);
        }
    }
}

using Df.Magalu.Challenge.Domain.ValueObject;
using System;
using System.Collections.Generic;

namespace Df.Magalu.Challenge.Domain.Interfaces.Entity
{
    public interface IClient
    {
        Guid _id { get; }
        DateTime CreationDate { get; }
        string Name { get; }
        string Email { get; }
        List<Product> FavoritesProducts { get; }


        void DefineNome(string name);
        void DefineEmail(string email);
        void AddFavoriteProduct(Product product);
    }
}

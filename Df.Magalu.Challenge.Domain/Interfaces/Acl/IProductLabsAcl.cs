using Df.Magalu.Challenge.Domain.ValueObject;
using System;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Domain.Interfaces.Acl
{
    public interface IProductLabsAcl
    {
        Task<Product> GetProductById(Guid id);
    }
}

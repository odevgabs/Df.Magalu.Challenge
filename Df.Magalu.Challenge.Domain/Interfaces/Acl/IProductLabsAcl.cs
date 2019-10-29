using Df.Magalu.Challenge.Domain.Dto;
using Df.Magalu.Challenge.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Domain.Interfaces.Acl
{
    public interface IProductLabsAcl
    {
        Task<Product> GetProductById(Guid id);
    }
}

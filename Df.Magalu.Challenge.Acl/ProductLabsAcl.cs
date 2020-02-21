using Microsoft.Extensions.Configuration;
using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Df.Magalu.Challenge.Domain.Interfaces.Acl;
using Df.Magalu.Challenge.Domain.Dto;
using AutoMapper;
using Df.Magalu.Challenge.Domain.ValueObject;

namespace Df.Magalu.Challenge.Acl
{
    public class ProductLabsAcl : IProductLabsAcl
    {

        private readonly string _apiLuizaLabsBaseUrl;
        private IMapper _mapper;
        public ProductLabsAcl(IConfiguration configuration, IMapper mapper)
        {
            _apiLuizaLabsBaseUrl = configuration.GetSection("ApiLuizaLabsBase").Value;
            _mapper = mapper;

        }
        
        public async Task<Product> GetProductById(Guid id)
        {
            var productLabsDto = await _apiLuizaLabsBaseUrl
                .AppendPathSegment($"product/{id}")
                .GetJsonAsync<ProductLabsDto>();

            Product result =_mapper.Map<Product>(productLabsDto);
            return result;
        }
    }
}
